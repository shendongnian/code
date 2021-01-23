    IInputArray image, 
    String faceFileName, String eyeFileName,
    List<Rectangle> faces
    using( CascadeClassifier face = new CascadeClassifier( faceFileName ) )
    {
        using( UMat ugray = new UMat() )
        {
            CvInvoke.CvtColor( image, ugray, Emgu.CV.CvEnum.ColorConversion.Bgr2Gray );
    
            //normalizes brightness and increases contrast of the image
            CvInvoke.EqualizeHist( ugray, ugray );
    
            //Detect the faces  from the gray scale image and store the locations as rectangle                   
            Rectangle[] facesDetected = face.DetectMultiScale(
               ugray, 1.1, 10, new Size( 20, 20 ) );
    
            faces.AddRange( facesDetected );
        }
    }
