    private void panel1_Paint(object sender, PaintEventArgs e)
    {
        string s = "";
        foreach(char c in panel1.Text) s += c.ToString() + "\r\n";
        e.Graphics.DrawString(s, panel1.Font, Brushes.Black, Point.Empty);
    }
    private void panel2_Paint(object sender, PaintEventArgs e)
    {
        float leading = 1.5f;
        Dictionary<char, Size> charSizes = new Dictionary<char, Size>();
        foreach (char c in panel2.Text)
            if (!charSizes.ContainsKey(c))
            {
                SizeF sf = e.Graphics.MeasureString(c.ToString(), panel2.Font);
                charSizes.Add(c, new Size((int)sf.Width, (int)sf.Height) );
            }
        float y = 0f;
        foreach (char c in panel2.Text)
        {
            e.Graphics.DrawString(c.ToString(), panel2.Font, Brushes.Black, 
                       new Point( ( panel2.Width - charSizes[c].Width) / 2, (int)y) );
            y += charSizes[c].Height + leading;
        }
    }
