        int oh = listBox1.Height;
        listBox1.Height = listBox1.ItemHeight * listBox1.Items.Count;
        Bitmap bmp = new Bitmap(this.listBox1.Width, this.listBox1.Height);
        this.listBox1.DrawToBitmap(bmp, this.listBox1.ClientRectangle);
        bmp.Save(@"Data.png" , System.Drawing.Imaging.ImageFormat.Png);
        listBox1.Height = oh;
