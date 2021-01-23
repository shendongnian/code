    public void Redraw()
    {
        using (var g = Graphics.FromImage(pictureBox1.Image))
        {
            foreach (var shape in shapes)
            {
                shape.Draw(g);
            }
        }
        pictureBox1.Invalidate();
    }
