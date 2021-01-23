    public MyLabel ()
    {
        //..
        Paint += MyLabel _Paint;
        Format = "{0}";
    }
    public string Format { get; set; }
    void MyLabel _Paint(object sender, PaintEventArgs e)
    {
        using (SolidBrush fBrush = new SolidBrush(this.ForeColor) )
        using (SolidBrush bBrush = new SolidBrush(this.BackColor) )
        { 
            if (Format == "") Format = "{0}";
            e.Graphics.FillRectangle(bBrush, this.ClientRectangle);
            string fs = string.Format(Format, Text);
            e.Graphics.DrawString(fs, this.Font, fBrush, new Point(Margin.Left, Margin.Top));
        }
    }
