    Matrix<double> input = new Matrix<double>(5, 8);
    var r = new Random();
    for (int row = 0; row < 5; row++) {
    	input.Data[row,0] = r.Next(0, 10);     // low variance
    	input.Data[row,1] = r.Next(0, 20);     // low variance
    	input.Data[row,2] = r.Next(80, 210);   // high variance
    	input.Data[row,3] = r.Next(0, 240);    // highest variance
    	input.Data[row,4] = r.Next(20, 21);    // very low variance
    	input.Data[row,5] = r.Next(0, 10);     // low variance
    	input.Data[row,6] = r.Next(0, 10);     // low variance
    	input.Data[row,7] = r.Next(200, 210);  // low variance
    }
    
    // CHANGE HERE
    // Matrix<> was not changed by PCACompute(), so change eigenvectors to a Mat
    var eigenvectors = new Mat(8, 8, DepthType.Cv64F, 1);
    
    // create *empty* mean array so that PCACompute() calculates its own means
    var means = new Mat();
    
    // Now the magic works fine.
    CvInvoke.PCACompute(input, means, eigenvectors);
