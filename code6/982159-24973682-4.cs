    private void panel1_Paint(object sender, PaintEventArgs e)
    {
        string s = "";
        foreach(char c in panel1.Text) s += c.ToString() + "\r\n";
        e.Graphics.DrawString(s, panel1.Font, Brushes.Black, Point.Empty);
        SizeF sf = e.Graphics.MeasureString(s, panel1.Font);    //**
        panel1.Size = new Size((int)sf.Width, (int)sf.Height);  //**
    }
    private void panel2_Paint(object sender, PaintEventArgs e)
    {
        float leading = -1.75f;  // <-- depends on font and taste
        float maxWidth = 0f;  //**
        Dictionary<char, Size> charSizes = new Dictionary<char, Size>();
        foreach (char c in panel2.Text)
            if (!charSizes.ContainsKey(c))
            {
                SizeF sf = e.Graphics.MeasureString(c.ToString(), panel2.Font);
                charSizes.Add(c, new Size((int)sf.Width, (int)sf.Height) );
                if (maxWidth < (int)sf.Width) maxWidth = (int)sf.Width;   //**
            }
        panel2.Width = (int)(maxWidth * 2);   // for panel size  //**
        float y = 0f;
        foreach (char c in panel2.Text)
        {
            e.Graphics.DrawString(c.ToString(), panel2.Font, Brushes.Black, 
                       new Point( ( panel2.Width - charSizes[c].Width) / 2, (int)y) );
            y += charSizes[c].Height + leading;
        }
        panel2.Height = (int)y;  //**
    }
