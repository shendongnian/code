    Pen pen = new Pen(Color.Black, 3);
    Pen r = new Pen(Color.YellowGreen, 3);
    Graphics b = panel2.CreateGraphics();
    b.DrawEllipse(pen, 6, 6, 90, 90);
    b.SmoothingMode = SmoothingMode.AntiAlias;
    b.DrawLine(r, new Point(50, 90), new Point(50, 0));
    b.DrawEllipse(pen, 6, 6, 30, 30);
