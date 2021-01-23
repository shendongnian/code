        Mat im = Cv2.ImRead(@"Circleboard.png");                     
        im = im.CvtColor(OpenCvSharp.ColorConversion.RgbToGray);
        Size patternsize = new Size(4, 11);
        var centers = new List<Point2f>();
        if (Cv2.FindCirclesGrid(im, patternsize, OutputArray<Point2f>.Create(centers), FindCirclesGridFlag.AsymmetricGrid | FindCirclesGridFlag.Clustering))
        {
            // Ok, finds 44 circles
            Console.WriteLine(centers.Count());
        }
        Point2f[] centers2 = null;
        if (Cv2.FindCirclesGrid(im, patternsize, out centers2, FindCirclesGridFlag.AsymmetricGrid | FindCirclesGridFlag.Clustering))
        {
            // Crashes with AccessViolationException
            Console.WriteLine(centers2.Count());
        }
