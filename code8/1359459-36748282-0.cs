       if(images.Length == 1)
        {
            string imgToDisplay = images[images.Length];
            Image img = new Bitmap(imgToDisplay);
            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, ImageFormat.Png);
                ms.WriteTo(context.Response.OutputStream);
            }
        }
