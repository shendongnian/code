    // At this point, we should have obtained an useful machine. Let's
    // see if it can understand a few examples it hasn't seem before:
    
    double[][] a = 
    { 
        new double[] { 1, 1, 1 },
        new double[] { 7, 2, 5 },
        new double[] { 2, 5, 1 },
    };
    
    double[][] b =
    {
        new double[] { 7, 5, 2 },
        new double[] { 4, 2, 5 },
        new double[] { 1, 1, 1 },
    };
    
    // Following the aforementioned logic, sequence (a) should be
    // classified as -1, and sequence (b) should be classified as +1.
    
    int resultA = System.Math.Sign(svm.Compute(Matrix.Concatenate(a))); // -1
    int resultB = System.Math.Sign(svm.Compute(Matrix.Concatenate(b))); // +1
