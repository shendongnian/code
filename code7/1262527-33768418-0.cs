    List<Rectangle> rectangles = new List<Rectangle>();
    Rectangle mRect = Rectangle.Empty;
    
    private void drawPanel_MouseUp(object sender, MouseEventArgs e)
    {
       isLeft = false;
       rectangles.Add(mRect);
       mRect = Rectangle.Empty;
       drawPanel.Invalidate();
    }
    private void drawPanel_Paint(object sender PaintEventArgs e)
    {
       foreach (Rectangle rect in rectangles) e.Graphics.DrawRectangle(lPen, rect );
       e.Graphics.DrawRectangle(Pens.Orange, mRect);  // or whatever..
    }
