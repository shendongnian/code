    static List<Rect> RunTextRecog(string inFile)
    {
        List<Rect> boundRect = new List<Rect>();
        using (Mat img = new Mat(inFile))
        using (Mat img_gray = new Mat())
        using (Mat img_sobel = new Mat())
        using (Mat img_threshold = new Mat())
        {
            Cv2.CvtColor(img, img_gray, ColorConversionCodes.BGR2GRAY);
            Cv2.Sobel(img_gray, img_sobel, MatType.CV_8U, 1, 0, 3, 1, 0, BorderTypes.Default);
            Cv2.Threshold(img_sobel, img_threshold, 0, 255, ThresholdTypes.Otsu | ThresholdTypes.Binary);
            using (Mat element = Cv2.GetStructuringElement(MorphShapes.Rect, new Size(10, 15)))
            {
                Cv2.MorphologyEx(img_threshold, img_threshold, MorphTypes.Close, element);
                Point[][] edgesArray = img_threshold.Clone().FindContoursAsArray(RetrievalModes.External, ContourApproximationModes.ApproxNone);
                foreach (Point[] edges in edgesArray)
                {
                    Point[] normalizedEdges = Cv2.ApproxPolyDP(edges, 17, true);
                    Rect appRect = Cv2.BoundingRect(normalizedEdges);
                    boundRect.Add(appRect);
                }
            }
        }
        return boundRect;
    }
