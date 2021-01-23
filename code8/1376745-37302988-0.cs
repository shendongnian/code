    public static void SolvePnP(
    	IEnumerable<Point3f> objectPoints,
    	IEnumerable<Point2f> imagePoints,
    	double[,] cameraMatrix,
    	IEnumerable<double> distCoeffs,
    	out double[] rvec,
    	out double[] tvec,
    	bool useExtrinsicGuess = false,
    	SolvePnPFlags flags = SolvePnPFlags.Iterative
    )
