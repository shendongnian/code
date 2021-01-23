            byte[] imagebuffer;
            using (Image img = Image.FromFile(@"c:\temp_10\sample.gif"))
            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, ImageFormat.Jpeg);
                imagebuffer = ms.ToArray();
            }
            //write to fs (if you need...)
            File.WriteAllBytes(@"c:\temp_10\sample.jpg", imagebuffer);
