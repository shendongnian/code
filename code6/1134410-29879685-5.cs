    void drawALittle()
    {
        Rectangle rectangleObj = new Rectangle(10, 10, 200, 200);
        using (Pen myPen = new Pen(Color.Plum, 3))
        using (Graphics G = Graphics.FromImage(bmp))
        {
            G.DrawEllipse(myPen, rectangleObj);
            //..
        }
        this.Invalidate();
    }
