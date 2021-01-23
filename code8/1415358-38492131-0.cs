            AForge.Imaging.SusanCornersDetector scd = new AForge.Imaging.SusanCornersDetector();
            List<AForge.IntPoint> corners = scd.ProcessImage(FilterMap);
            AForge.IntPoint XYMin, XYMax;
            AForge.Math.Geometry.PointsCloud.GetBoundingRectangle(corners, out XYMin, out XYMax);
            Console.WriteLine("min X: " + XYMin.X.ToString() + " Y: " + XYMin.Y.ToString());
            Console.WriteLine("max X: " + XYMax.X.ToString() + " Y: " + XYMax.Y.ToString());
