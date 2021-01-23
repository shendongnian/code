    private void button6_Click(object sender, EventArgs e)
    {
        // target size:
        Size sz = pictureBox1.ClientSize;
        Bitmap bmp = new Bitmap(sz.Width, sz.Height);
        // the data array:
        double[,] data = new double[222, 222];
        // step sizes:
        float stepX = 1f * sz.Width / data.GetLength(0);
        float stepY = 1f * sz.Height / data.GetLength(1);
        // create a few stop colors:
        List<Color> baseColors = new List<Color>();  // create a color list
        baseColors.Add(Color.RoyalBlue);
        baseColors.Add(Color.LightSkyBlue);
        baseColors.Add(Color.LightGreen);
        baseColors.Add(Color.Yellow);
        baseColors.Add(Color.Orange);
        baseColors.Add(Color.Red);
        // and the interpolate a larger number of grdient colors:
        List<Color> colors = interpolateColors(baseColors, 1000);
        // a few boring test data
        Random rnd = new Random(1);
        for (int x = 0; x < data.GetLength(0); x++)
        for (int y = 0; y < data.GetLength(1); y++)
        {
            data[x, y] = rnd.Next( (int) (300 + Math.Sin(x * y / 999) * 200 )) +
                            rnd.Next(  x +  y + 111);
        }
        // now draw the data:
        using (Graphics G = Graphics.FromImage(bmp))
        for (int x = 0; x < data.GetLength(0); x++)
            for (int y = 0; y < data.GetLength(1); y++)
            {
                using (SolidBrush brush = new SolidBrush(colors[(int)data[x, y]]))
                    G.FillRectangle(brush, x * stepX, y * stepY, stepX, stepY);
            }
        // and display the result
        pictureBox1.Image = bmp;
    }
