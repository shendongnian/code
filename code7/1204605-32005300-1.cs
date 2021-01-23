    using (Bitmap bitmap = new Bitmap(width, height))
            {
                using (Graphics graphics = Graphics.FromImage(bitmap))
                {
                    graphics.Clear(Color.Black);
                    /* SNIP, a bunch of image manipulation here */
                    //I read a little around - maybe your graphics operations are out of sync?
                    graphics.Flush(FlushIntention.Sync);
                    graphics.Save();
                }
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    Bitmap temp = new Bitmap(bitmap);
                    //temp.Save("image.png", ImageFormat.Png); //this worked obviously
                    temp.Save(memoryStream, ImageFormat.Png);
                    pictureBox1.Image = Image.FromStream(memoryStream); //a huge black box appears - everything is working fine
                }
            }
        }
