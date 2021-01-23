    // Let's say we have the following data to be classified
    // into three possible classes. Those are the samples:
    // 
    double[][] inputs =
    {
        //               input         output
        new double[] { 0, 1, 1, 0 }, //  0 
        new double[] { 0, 1, 0, 0 }, //  0
        new double[] { 0, 0, 1, 0 }, //  0
        new double[] { 0, 1, 1, 0 }, //  0
        new double[] { 0, 1, 0, 0 }, //  0
        new double[] { 1, 0, 0, 0 }, //  1
        new double[] { 1, 0, 0, 0 }, //  1
        new double[] { 1, 0, 0, 1 }, //  1
        new double[] { 0, 0, 0, 1 }, //  1
        new double[] { 0, 0, 0, 1 }, //  1
        new double[] { 1, 1, 1, 1 }, //  2
        new double[] { 1, 0, 1, 1 }, //  2
        new double[] { 1, 1, 0, 1 }, //  2
        new double[] { 0, 1, 1, 1 }, //  2
        new double[] { 1, 1, 1, 1 }, //  2
    };
    
    int[] outputs = // those are the class labels
    {
        0, 0, 0, 0, 0,
        1, 1, 1, 1, 1,
        2, 2, 2, 2, 2,
    };
    
    // Create the multi-class learning algorithm for the machine
    var teacher = new MulticlassSupportVectorLearning<Gaussian>()
    {
        // Configure the learning algorithm to use SMO to train the
        //  underlying SVMs in each of the binary class subproblems.
        Learner = (param) => new SequentialMinimalOptimization<Gaussian>()
        {
            // Estimate a suitable guess for the Gaussian kernel's parameters.
            // This estimate can serve as a starting point for a grid search.
            UseKernelEstimation = true
        }
    };
    
    // Configure parallel execution options
    teacher.ParallelOptions.MaxDegreeOfParallelism = 1;
    
    // Learn a machine
    var machine = teacher.Learn(inputs, outputs);
    
    // Obtain class predictions for each sample
    int[] predicted = machine.Decide(inputs);
    
    // Get class scores for each sample
    double[] scores = machine.Score(inputs);
    
    // Compute classification error
    double error = new ZeroOneLoss(outputs).Loss(predicted);
