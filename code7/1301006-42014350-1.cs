    using Emgu.CV;
    using Emgu.CV.CvEnum;
    using Emgu.CV.Structure;
    using Emgu.CV.UI;
    using System.Drawing;
    
    ...
    
    //Create a 3 channel image of 400x200
    using (Mat img = new Mat(200, 400, DepthType.Cv8U, 3)) 
    {
       img.SetTo(new Bgr(255, 0, 0).MCvScalar); // set it to Blue color
    
       //Draw "Hello, world." on the image using the specific font
       CvInvoke.PutText(
          img, 
          "Hello, world", 
          new System.Drawing.Point(10, 80), 
          FontFace.HersheyComplex, 
          1.0, 
          new Bgr(0, 255, 0).MCvScalar);
       
       //Show the image using ImageViewer from Emgu.CV.UI
       ImageViewer.Show(img, "Test Window");
    }
