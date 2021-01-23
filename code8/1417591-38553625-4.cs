    public void    SaveAsImageTo24bpp( Image img,string fname)
        {
            var bmp = new Bitmap(img.Width, img.Height, PixelFormat.Format24bppRgb);
            using (var gr = Graphics.FromImage(bmp))
                gr.DrawImage(img, new Rectangle(0, 0, img.Width, img.Height));
            // bitmapImage.Save(dlg.FileName);
            var image = img.ImageTo24bpp();
            ImageConverter imgCon = new ImageConverter();
            var bytes = (byte[])imgCon.ConvertTo(image, typeof(byte[]));
             File.WriteAllBytes(fname,bytes);
        }
