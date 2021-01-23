    Bitmap bmp = new Bitmap(100, 30);
    Graphics g = Graphics.FromImage(bmp);
    g.Clear(Color.Navy);
    g.DrawString(code, new Font("Courier", 16),
                         new SolidBrush(Color.WhiteSmoke), 2, 2);
    g.FillRectangle(new HatchBrush(HatchStyle.BackwardDiagonal, Color.FromArgb(255,0,0,0),Color.Transparent), g.ClipBounds );
    g.FillRectangle(new HatchBrush(HatchStyle.ForwardDiagonal, Color.FromArgb(255, 0, 0, 0), Color.Transparent), g.ClipBounds);
