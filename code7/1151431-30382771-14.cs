    private void checkBox1_Paint(object sender, PaintEventArgs e)
    {
        checkBox1.Text = "";
        string[] texts =  checkBox1.Tag.ToString().Split('§');
        Font font1 = new Font(checkBox1.Font, FontStyle.Regular);
        e.Graphics.DrawString(texts[0], checkBox1.Font, Brushes.Black, 25, 3);
        if (texts.Length > 0)
        {
            SizeF s = e.Graphics.MeasureString(texts[1], checkBox1.Font, checkBox1.Width - 25);
            checkBox1.Height = (int) s.Height + 30;
            e.Graphics.DrawString(texts[1], font1, Brushes.Black, 
                                  new RectangleF(new PointF(25, 25), s));
        }
    }
