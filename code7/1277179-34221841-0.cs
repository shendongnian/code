         private Bitmap Convert565bppTo24bpp(Bitmap ConvertMe)
         {
           Bitmap clone = new Bitmap(ConvertMe.Width, ConvertMe.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);//.Format32bppPArgb);
           using (Graphics gr = Graphics.FromImage(clone)) 
            { gr.DrawImage(ConvertMe, new Rectangle(0, 0, clone.Width, clone.Height)); }
            return clone;
         }
