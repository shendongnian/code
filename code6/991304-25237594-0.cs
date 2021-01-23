    private void MyPictureBoxPaint(object sender, PaintEventArgs e)
    {
        Graphics g = e.Graphics;
        using (var pen = new Pen(Color.Black, 2))
        {
            foreach (var rect in Rectangles)
            {
                g.DrawRectangle(pen, rect);
            }
        }
    }
