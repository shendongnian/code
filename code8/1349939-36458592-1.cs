              using (Graphics gra = Graphics.FromImage(imgOriginal))
              {
                Bitmap bmLogo = new Bitmap(imgLogo);
                int nWidth = bmLogo.Size.Width;
                int nHeight = bmLogo.Size.Height;
                int nLeft = (imgOriginal.Width / 2) - (nWidth / 2);
                int nTop = (imgOriginal.Height / 2) - (nHeight / 2);
                gra.DrawImage(bmLogo, nLeft, nTop, nWidth, nHeight);
                
               // Convert the image to byte[]
               System.IO.MemoryStream stream = new System.IO.MemoryStream();
               bitmap.Save(bmLogo, System.Drawing.Imaging.ImageFormat.Bmp);
               byte[] imageBytes = bmLogo.ToArray();
    
              // Convert byte[] to Base64 String
             string base64String = Convert.ToBase64String(imageBytes);
    
            // Write the bytes (as a Base64 string
            return base64String;
                
            }
          
