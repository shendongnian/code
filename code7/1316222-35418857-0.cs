    IplImage input = new IplImage(@"C:\Users\20396600\Downloads\cont.jpg");
    IplImage gray = new IplImage(input.Size, BitDepth.U8, 1);
    IplImage invert = gray.Clone();
    input.CvtColor(gray, ColorConversion.BgrToGray); //Make it gray - could probably skip this and just threshold
    gray.Threshold(invert, 70, 255, ThresholdType.BinaryInv); //Make sure it's inverted
    private IplImage RemoveNoise(IplImage image, int minArea)
    {
        IplImage output = new IplImage(image.Size, BitDepth.U8, 3);//image.Depth, 1);
        output.Set(CvColor.Black);
        CvSeq<CvPoint> contoursRaw;
        using (CvMemStorage storage = new CvMemStorage())
        {
            //find contours
            Cv.FindContours(image, storage, out contoursRaw, CvContour.SizeOf, ContourRetrieval.Tree, ContourChain.ApproxSimple);
            //Taken straight from one of the OpenCvSharp Samples
            using (CvContourScanner scanner = new CvContourScanner(image, storage, CvContour.SizeOf, ContourRetrieval.Tree, ContourChain.ApproxSimple))
            {
                foreach (CvSeq<CvPoint> c in scanner)
                {
                    //Some contours come back negative so make them all positive
                    double area = Math.Abs(c.ContourArea());
                    //Uncomment below to see the area of each contour
                    //Console.WriteLine(area.ToString());
                    if (area >= minArea)
                    {
                        // -1 means filled
                        output.DrawContours(c, CvColor.White, CvColor.Green, 0, -1, LineType.AntiAlias);
                        //Uncomment these two lines to understand which contours area being drawn
                        //Cv.ShowImage("Window", output);
                        //Cv.WaitKey();
                    }
                }
            } 
        }
        output.SaveImage("output.png");
        return output;
    }
