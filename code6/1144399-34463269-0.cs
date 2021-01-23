    using System;
    using OpenCvSharp;
    
    namespace EdgeDetect
    {
        class Template
        {
            public Template()
            {
                CvCapture cap = CvCapture.FromCamera(1);
                CvWindow w = new CvWindow("Template Matching");
    
                IplImage tpl = Cv.LoadImage("speedlimit55.jpg", LoadMode.Color);
    
                CvPoint minloc, maxloc;
    
                double minval, maxval;
    
                while (CvWindow.WaitKey(10) < 0)
                {
                    IplImage img = cap.QueryFrame();
                    IplImage res = Cv.CreateImage(Cv.Size(img.Width - tpl.Width + 1, img.Height - tpl.Height + 1), BitDepth.F32, 1);
                    Cv.MatchTemplate(img, tpl, res, MatchTemplateMethod.CCoeff);
                    Cv.MinMaxLoc(res, out minval, out maxval, out minloc, out maxloc, null);
                    Cv.Rectangle(img, Cv.Point(minloc.X, minloc.Y), Cv.Point(minloc.X + tpl.Width, minloc.Y + tpl.Height), CvColor.Red, 1, 0, 0);
                    w.Image = img;
                    Cv.ReleaseImage(res);
                    Cv.ReleaseImage(img);
                }
            }
        }
    }
