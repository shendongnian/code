    public void Draw(Graphics g){
    Bitmap canvas = new Bitmap(pnlHang.Width, pnlHang.Height);
    Graphics canvg = Graphics.FromImage(canvas);
    canvg.FillRectangle(Brushes.Black, new Rectangle(new Point(0, 0), pnlHang.Size);
    //Draw using canvg
    canvg.Dispose();
    g.DrawImage(canvas, new Rectangle(new Point(0, 0), pnlHang.Size));
    }
