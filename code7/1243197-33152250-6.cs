    private void button1_Click(object sender, EventArgs e)
    {
        string text = "Y";                  // whatever
        Bitmap bmp = new Bitmap(64, 64);    // whatever
        bmp.SetResolution(96, 96);          // whatever
        float fontSize = 32f;               // whatever
        using ( Graphics g = Graphics.FromImage(bmp))
        using ( GraphicsPath GP = new GraphicsPath())
        using ( FontFamily fontF = new FontFamily("Arial"))
        {
            testPattern(g, bmp.Size);      // optional
            GP.AddString(text, fontF, 0, fontSize, Point.Empty,
                         StringFormat.GenericTypographic);
            // this is the net bounds without any whitespace:
            Rectangle br = Rectangle.Round(GP.GetBounds());
            
            g.DrawRectangle(Pens.Red,br); // just for testing
            // now we center:
            g.TranslateTransform( (bmp.Width - br.Width )  / 2 - br.X,
                                  (bmp.Height - br.Height )/ 2 - br.Y);
            // and fill
            g.FillPath(Brushes.Black, GP);
            g.ResetTransform();
        }
        // whatever you want to do..
        pictureBox1.Image = bmp;
        bmp.Save("D:\\__test.png", ImageFormat.Png);
    }
