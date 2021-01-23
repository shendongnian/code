    GraphicsPath path = new GraphicsPath();
    path.AddLine(  0,   0, 100,   0);
    path.AddLine(100,   0, 100, 100);
    path.AddLine(100, 100,   0, 100);
    path.AddLine(  0, 100,   0,   0);
    var sw = Stopwatch.StartNew();
    for (int x = 0; x < 500; ++x)
        for (int y = 0; y < 500; ++y)
            path.IsVisible(x, y);
    Console.WriteLine(sw.ElapsedMilliseconds);
