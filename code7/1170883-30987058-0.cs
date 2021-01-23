    Panel somePanel = panel1;
    using (Graphics G = somePanel.CreateGraphics())
    {
        G.FillRectangle(SystemBrushes.Window, new Rectangle(11, 11, 22, 22));
        G.FillRectangle(SystemBrushes.Window, new Rectangle(44, 44, 66, 66));
        G.FillRectangle(SystemBrushes.Window, new Rectangle(11, 44, 22, 66));
        G.FillRectangle(SystemBrushes.Window, new Rectangle(44, 11, 66, 22));
        ControlPaint.DrawBorder3D(G, new Rectangle(11, 11, 22, 22));
        ControlPaint.DrawBorder3D(G, new Rectangle(44, 44, 66, 66));
        ControlPaint.DrawBorder3D(G, new Rectangle(11, 44, 22, 66));
        ControlPaint.DrawBorder3D(G, new Rectangle(44, 11, 66, 22));
    }
    Console.WriteLine("BorderSize.Width = " + SystemInformation.BorderSize.Width);
    Console.WriteLine("Border3DSize.Width = " + SystemInformation.Border3DSize.Width);
