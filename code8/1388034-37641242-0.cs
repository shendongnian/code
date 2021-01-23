    // Sample input data
    double[][] inputs =
    {
        new double[] { -1, 3, 2 },
        new double[] { -1, 3, 2 },
        new double[] { -1, 3, 2 },
        new double[] { 10, 82, 4 },
        new double[] { 10, 15, 4 },
        new double[] { 0, 0, 1 },
        new double[] { 0, 0, 2 },
    };
    
    // Output for each of the inputs
    int[] outputs = { 0, 3, 1, 2 };
    
    
    // Create a new polynomial kernel
    IKernel kernel = new Polynomial(2);
    
    // Create a new Multi-class Support Vector Machine with one input,
    //  using the linear kernel and for four disjoint classes.
    var machine = new MulticlassSupportVectorMachine(inputs: 3, kernel: kernel, classes: 4);
    
    // Create the Multi-class learning algorithm for the machine
    var teacher = new MulticlassSupportVectorLearning(machine, inputs, outputs);
    
    // Configure the learning algorithm to use SMO to train the
    //  underlying SVMs in each of the binary class subproblems.
    teacher.Algorithm = (svm, classInputs, classOutputs, i, j) =>
        new SequentialMinimalOptimization(svm, classInputs, classOutputs);
    
    // Run the learning algorithm
    double error = teacher.Run(); // output should be 0
    
    // Compute the decision output for one of the input vectors
    int decision = machine.Compute( new double[] { -1, 3, 2 });
