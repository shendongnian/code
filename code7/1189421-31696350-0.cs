    protected override void OnRender(DrawingContext dc)
    {
        SolidColorBrush mySolidColorBrush  = new SolidColorBrush();
        mySolidColorBrush.Color = Colors.LimeGreen;
        Pen myPen = new Pen(Brushes.Blue, 10);
        Rect myRect = new Rect(0, 0, 500, 500);
        dc.DrawRectangle(mySolidColorBrush, myPen, myRect);
    }
