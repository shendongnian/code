    IplImage input = new IplImage(@"C:\Users\20396600\Downloads\cont.jpg");
    IplImage gray = new IplImage(input.Size, BitDepth.U8, 1);
    IplImage invert = gray.Clone();
    input.CvtColor(gray, ColorConversion.BgrToGray);
    gray.Threshold(invert, 70, 255, ThresholdType.BinaryInv);
    RemoveNoise(invert, 150);
    private IplImage RemoveNoise(IplImage image, int minArea)
    {
        IplImage output = new IplImage(image.Size, BitDepth.U8, 3);//image.Depth, 1);
        output.Set(CvColor.Black);
        CvSeq<CvPoint> contoursRaw;
        using (CvMemStorage storage = new CvMemStorage())
        {
            //find contours
            Cv.FindContours(image, storage, out contoursRaw, CvContour.SizeOf, ContourRetrieval.Tree, ContourChain.ApproxSimple);
            //Taken straight from one of the OpenCvSharp samples
            using (CvContourScanner scanner = new CvContourScanner(image, storage, CvContour.SizeOf, ContourRetrieval.Tree, ContourChain.ApproxSimple))
            {
                foreach (CvSeq<CvPoint> c in scanner)
                {
                    //Some contours are negative so make them all positive for easy comparison
                    double area = Math.Abs(c.ContourArea());
                    //Uncomment below to see the area of each contour
                    //Console.WriteLine(area.ToString());
                    if (area >= minArea)
                    {
                        List<CvPoint[]> points = new List<CvPoint[]>();
                        List<CvPoint> point = new List<CvPoint>();
                        foreach (CvPoint p in c.ToArray())
                            point.Add(p);
                        points.Add(point.ToArray());
                        
                        //Use FillPoly instead of DrawContours as requested
                        output.FillPoly(points.ToArray(), CvColor.Red, LineType.AntiAlias);
                        
                        //-1 means fill the polygon
                        //output.DrawContours(c, CvColor.White, CvColor.Green, 0, -1, LineType.AntiAlias);
                        
                        //Uncomment two lines below to see contours being drawn gradually
                        //Cv.ShowImage("Window", output);
                        //Cv.WaitKey();
                    }
                }
            } 
        }
        output.SaveImage("output.png");
        return output;
    }
