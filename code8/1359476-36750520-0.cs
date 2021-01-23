    CascadeClassifier mouth = new CascadeClassifier(Application.StartupPath + "/haarcascade_mcs_mouth.xml");
    Image<Bgr, Byte> currentframe= null;
    Image<Gray, byte> grayFrame = null;
    Capture grabber = new Capture();
    currentframe = grabber.QueryFrame().Resize(500, 320, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
     
                if (currentframe != null)
                {
                    grayFrame = currentframe.Convert<Gray, Byte>();
    
                    Rectangle[] mouthDetected = mouth.DetectMultiScale(grayFrame, 1.1, 10, Size.Empty, Size.Empty);
                 
                    // to draw rectangle 
                    foreach (Rectangle mouthFound in mouthDetected)
                    {
                       ...
                    }
                }
