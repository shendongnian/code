        static void Main(string[] args)
        {
            string filename = "Alliance.jpg";
            Mat imageIn = Cv2.ImRead(filename, ImreadModes.GrayScale).Resize(new Size(800, 600));
            Mat edges = new Mat();
            Cv2.Canny(imageIn, edges, 95, 100);
            //HoughLinesP
            LineSegmentPoint[] segHoughP = Cv2.HoughLinesP(edges, 1, Math.PI / 180, 100, 100, 10);
            
            Mat imageOutP = imageIn.EmptyClone();
            foreach (LineSegmentPoint s in segHoughP)
                imageOutP.Line(s.P1, s.P2, Scalar.White, 1, LineTypes.AntiAlias, 0);
            using (new Window("Edges", WindowMode.AutoSize, edges))
            using (new Window("HoughLinesP", WindowMode.AutoSize, imageOutP))
            {
                Window.WaitKey(0);
            }
        }
