    private void Form1_Paint(object sender, PaintEventArgs e)
    {
        int w = ClientSize.Width / width;
        int h = ClientSize.Height / height;
        for (int j = 0; j < height; j++) 
            for (int i = 0; i < width; i++)
            {
                using (SolidBrush brush = new SolidBrush(colors[i,j]))
                e.Graphics.FillRectangle(brush, i * w, j * h, w, h);
            }
    }
