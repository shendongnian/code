    private void button3_Click(object sender, EventArgs e)
    {
        Color originalColor;
        int grayScale;
        var sb = new StringBuilder();
        File2 = new Bitmap(File);
        for (int i = 0; i < File2.Height; i++)
        {
            for (int j = 0; j < File2.Width; j++)
            {
                sb.Append("a");
                originalColor = File2.GetPixel(i, j);
                grayScale = (int)((originalColor.R) + (originalColor.G) + (originalColor.B)) / 3;
                if (grayScale > 127)
                {
                    sb.Append("1 ");
                }
                else
                {
                    sb.Append("0 ");
                }
            }
            sb.Append("\n");
        }
        // after all iterations
        textBox1.Text = sb.ToString();
    }
