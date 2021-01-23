    using OpenCvSharp;
    using OpenCvSharp.Util;
    static void RunTemplateMatch(string reference, string template)
    {
        using (Mat refMat = new Mat(reference))
        using (Mat tplMat = new Mat(template))
        using (Mat res = new Mat(refMat.Rows - tplMat.Rows + 1, refMat.Cols - tplMat.Cols + 1, MatType.CV_32FC1))
        {
            //Convert input images to gray
            Mat gref = refMat.CvtColor(ColorConversionCodes.BGR2GRAY);
            Mat gtpl = tplMat.CvtColor(ColorConversionCodes.BGR2GRAY);
            Cv2.MatchTemplate(gref, gtpl, res, TemplateMatchModes.CCoeffNormed);
            Cv2.Threshold(res, res, 0.8, 1.0, ThresholdTypes.Tozero);
            while (true)
            {
                double minval, maxval, threshold = 0.8;
                Point minloc, maxloc;
                Cv2.MinMaxLoc(res, out minval, out maxval, out minloc, out maxloc);
                if (maxval >= threshold)
                {
                    //Setup the rectangle to draw
                    Rect r = new Rect(new Point(maxloc.X, maxloc.Y), new Size(tplMat.Width, tplMat.Height));
                    
                    //Draw a rectangle of the matching area
                    Cv2.Rectangle(refMat, r, Scalar.LimeGreen, 2);
                    //Fill in the res Mat so you don't find the same area again in the MinMaxLoc
                    Rect outRect;
                    Cv2.FloodFill(res, maxloc, new Scalar(0), out outRect, new Scalar(0.1), new Scalar(1.0));
                }
                else
                    break;
            }
            Cv2.ImShow("Matches", refMat);
            Cv2.WaitKey();
        }
    }
