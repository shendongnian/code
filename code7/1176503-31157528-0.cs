    private void buttonDraw_Click(object sender, EventArgs e)
    {
        Bitmap bmp = new Bitmap(pictureBoxBarcode.ClientSize.Width,
                                pictureBoxBarcode.ClientSize.Height);
        using (Graphics g = Graphics.FromImage(bmp))
        {
           g.Clear(SystemColors.Control);
           ean13.DrawEan13Barcode(g, new System.Drawing.Point(0, 0));
        }
        // display:
        pictureBoxBarcode.Image = bmp;
        // save:
        bmp.Save(yourfilename,  ImageFormat.Png);
        // ..or..: 
        Save(bmp);
    }
