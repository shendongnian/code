        String barcode = "*" + pole.Text + "*";
        PointF point = new PointF(5f, 5f);
        float fontHeight = 20f;
        Bitmap bitmap = new Bitmap(123,123);
        using (Font ofont = new System.Drawing.Font("IDAutomationHC39M", fontHeight))
        {    // create a Graphics object to measure the barcode
            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                Size sz = Size.Round(graphics.MeasureString( barcode, ofont));
                bitmap = new Bitmap(sz.Width + 10, sz.Height + 10);
            } // create a new one with the right size to work on
            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                graphics.Clear(Color.White);
                graphics.DrawString(barcode, ofont, Brushes.Black, point);
            }
        }
        box.Image = bitmap;
        box.ClientSize = bitmap.Size;
        // bitmap.Save(fileName, ImageFormat.Png);
