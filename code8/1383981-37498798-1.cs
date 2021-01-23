    private void panel1_Paint(object sender, PaintEventArgs e)
    {
        if (checkBox1.Checked)
        {
            e.Graphics.TranslateTransform(0, panel1.Height);
            e.Graphics.ScaleTransform(1, -1);
        }
        e.Graphics.DrawRectangle(Pens.Violet, 1, 1, 33, 33);
        e.Graphics.DrawRectangle(Pens.OrangeRed, 11, 11, 133, 55);
        e.Graphics.DrawRectangle(Pens.Magenta, 44, 11, 233, 77);
        e.Graphics.DrawRectangle(Pens.Olive, 55, 44, 33, 99);
    }
    private void checkBox1_CheckedChanged(object sender, EventArgs e)
    {
        panel1.Invalidate();
    }
