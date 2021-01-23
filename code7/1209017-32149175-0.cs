       class Program
       {
          static void Main(string[] args)
          {
             RasterSupport.SetLicense(@"C:\LEADTOOLS 19\Common\License\LEADTOOLS.LIC",
                                     File.ReadAllText(@"C:\LEADTOOLS 19\Common\License\LEADTOOLS.LIC.KEY"));
    
             Byte[] imageData = File.ReadAllBytes(@"C:\Users\Public\Documents\LEADTOOLS Images\cannon.jpg");
    
             using (MemoryStream ms = new MemoryStream(imageData))
             {
                // Put the pointer back to the beginning
                ms.Seek(0, System.IO.SeekOrigin.Begin);
    
                using( RasterCodecs codecs = new RasterCodecs())
                {
                   // Load the source image from disk
                   using (RasterImage image = codecs.Load(ms))  // on this line I got error...
                   {
                      //do something with the image
                   }
                }
             }
          }
       }
