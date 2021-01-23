    GraphicsPath path = new GraphicsPath();
    path.AddRectangle(new Rectangle(100, 100, 100, 100));
    GraphicsPath inversePath = new GraphicsPath();
    inversePath.AddRectangle(new Rectangle(100, 100, 100, 100));
    inversePath.AddRectangle(new Rectangle(0, 0, 500, 500));
    for (int x = 0; x < 500; ++x)
        for (int y = 0; y < 500; ++y)
            Trace.Assert(inversePath.IsVisible(x, y) == !path.IsVisible(x, y));
