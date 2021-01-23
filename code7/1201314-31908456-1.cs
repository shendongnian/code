    printDocument1.OriginAtMargins = true;
    Graphics g = e.Graphics;
    Brush brush = new SolidBrush(Color.Black);
    Pen blackPen = new Pen(Color.Black, 1);
    e.Graphics.PageUnit = GraphicsUnit.Millimeter;
    e.PageSettings.Margins = new Margins(0, 0, 0, 0);
    Rectangle rect = new Rectangle(10, 10, 20, 20);
    e.Graphics.DrawRectangle(blackPen, rect);
