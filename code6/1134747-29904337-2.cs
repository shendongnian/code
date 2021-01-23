    // At this point, we will have to "flat" out the input sequences from double[][][]
    // to a double[][] so they can be properly understood by the SVMs. The problem is 
    // that, normally, SVMs usually expect the data to be comprised of fixed-length 
    // input vectors and associated class labels. But in this case, we will be feeding
    // them arbitrary-length sequences of input vectors and class labels associated with
    // each sequence, instead of each vector.
    
    double[][] inputs = new double[sequences.Length][];
    for (int i = 0; i < sequences.Length; i++)
        inputs[i] = Matrix.Concatenate(sequences[i]);
    
    
    // Now we have to setup the Dynamic Time Warping kernel. We will have to
    // inform the length of the fixed-length observations contained in each
    // arbitrary-length sequence:
    // 
    var kernel = new Gaussian<DynamicTimeWarping>(new DynamicTimeWarping(length: 3));
    
    // Now we can create the machine. When using variable-length
    // kernels, we will need to pass zero as the input length:
    var svm = new KernelSupportVectorMachine(kernel, inputs: 0);
    
    // Create the Sequential Minimal Optimization learning algorithm
    var smo = new SequentialMinimalOptimization(svm, inputs, outputs);
    
    // And start learning it!
    double error = smo.Run(); // error will be 0.0
    
