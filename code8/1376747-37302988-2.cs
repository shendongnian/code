    using System.Collections.Generic;
    
    using OpenCvSharp;
    
    namespace Test
    {
        public class SolvePnPTest
        {
            public static void Main(string[] args)
            {
                var objectPoints = new List<Point3f>();
                objectPoints.Add(new Point3f(1, 2, 3));
                objectPoints.Add(new Point3f(1, 2, 3));
                objectPoints.Add(new Point3f(1, 2, 3));
                objectPoints.Add(new Point3f(1, 2, 3));
    
                var imagePoints = new List<Point2f>();
                imagePoints.Add(new Point2f(1, 2));
                imagePoints.Add(new Point2f(1, 2));
                imagePoints.Add(new Point2f(1, 2));
                imagePoints.Add(new Point2f(1, 2));
    
                var rvec = new double[3];
                var tvec = new double[3];
    
                var cameraMatrix = new double[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
                var distortionCoefficients = new double[] { 1, 2, 3, 4, 5 };
    
                /*
                Cv2.SolvePnP(
                    objectPoints,
                    imagePoints,
                    cameraMatrix,
                    distortionCoefficients,
                    out rvec,
                    out tvec);
                 * 
                 * */
    
                Cv2.SolvePnP(
                    new Mat(objectPoints.Count, 3, MatType.CV_64F, objectPoints.ToArray()),
                    new Mat(imagePoints.Count, 2, MatType.CV_64F, imagePoints.ToArray()),
                    new Mat(3, 3, MatType.CV_64F, cameraMatrix),
                    new Mat(5, 1, MatType.CV_64F, distortionCoefficients),
                    new Mat(3, 1, MatType.CV_64F),
                    new Mat(3, 1, MatType.CV_64F));
            }
        }
    }
