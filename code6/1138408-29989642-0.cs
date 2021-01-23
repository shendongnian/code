    byte[] imageBytes; 
    
    //Of course image bytes is set to the bytearray of your image      
    using (MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length))
        {
            using (Image img = Image.FromStream(ms))
            {
                int h = 100;
                int w = 100;
    
                using (Bitmap b = new Bitmap(img, new Size(w,h)))
                {
                    using (MemoryStream ms2 = new MemoryStream())
                    {
                        b.Save(ms2, System.Drawing.Imaging.ImageFormat.Jpeg);
                        imageBytes = ms2.ToArray();
                    }
                }
            }                        
        }    
