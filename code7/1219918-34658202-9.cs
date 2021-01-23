    ColorAnimation backgroundfade = ClrAnim(CanvasGS2.Color, Color.FromRgb(5, 3, 13), 1, 0.8, 0.1);
    backgroundfade.BeginTime = TimeSpan.FromSeconds(1.3);
    InitialiseInnerMenu.Children.Add(backgroundfade);
    try { UnregisterName("CanvasGS2"); }
    catch { }
    finally { RegisterName("CanvasGS2", CanvasGS2); }
    Storyboard.SetTargetName(backgroundfade, "CanvasGS2");
    Storyboard.SetTargetProperty(backgroundfade, new PropertyPath(GradientStop.ColorProperty));
