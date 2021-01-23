    using (Bitmap bitmap = new Bitmap(width, height))
            {
                using (Graphics graphics = Graphics.FromImage(bitmap))
                {
                    graphics.Clear(Color.Black);
                    /* SNIP, a bunch of image manipulation here */
                    graphics.Flush();
                }
                bitmap.Save("image.png", ImageFormat.Png);
                
            }
        }
