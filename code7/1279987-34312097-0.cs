    private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
    {
        pictureBox1.Invalidate();
    }
    private void pictureBox1_Paint(object sender, PaintEventArgs e)
    {
        Point mouse = pictureBox1.PointToClient(Cursor.Position);
        float zoom = 1f * pictureBox1.ClientRectangle.Width / pictureBox1.Image.Width;
        int pixelWidth = (int)Math.Round(zoom);
        int x = mouse.X / pixelWidth * pixelWidth;
        int y = mouse.Y / pixelWidth * pixelWidth;
        if (pictureBox1.ClientRectangle.Contains(mouse))
        {
            e.Graphics.DrawLine(Pens.White, x, y - 4, x, y + 4);
            e.Graphics.DrawLine(Pens.White, x - 4, y, x + 4, y);
        }
    }
    private void pictureBox1_MouseEnter(object sender, EventArgs e)
    {
        Cursor.Hide();
    }
    private void pictureBox1_MouseLeave(object sender, EventArgs e)
    {
        Cursor.Show();
        pictureBox1.Invalidate();  // clear the last one!
    }
