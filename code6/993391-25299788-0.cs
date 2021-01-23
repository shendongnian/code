    string[] lines = textBox1.Text.Split('\n');
    int iPos = 10;
    Bitmap myBitmap = new Bitmap(200,(lines.Length * 12) + 20);
    Graphics g = Graphics.FromImage(myBitmap);
    foreach(string line in lines)
    {
        g.DrawString(line, new Font("Arial", 40), Brushes.Black, new PointF(5, iPos));
        iPos += 12;
    }
