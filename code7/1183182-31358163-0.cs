    private void pictureBox1_Paint(object sender, PaintEventArgs e)
    {
        var pen1 = new System.Drawing.Pen(Color.Red);
        var pen2 = new System.Drawing.Pen(Color.Aqua);
        e.Graphics.DrawEllipse(pen1, 3, 3, 348.5f, 348.5f);
        e.Graphics.DrawEllipse(pen2, 1, 1, 269.5f, 348.5f);
    }
