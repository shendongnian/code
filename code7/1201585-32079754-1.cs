    var possibleRatios = new List<double>();
    possibleRatios.Add(1.0);
    possibleRatios.Add(1.4);
    possibleRatios.Add(2.4); //etc.
    double ratio = Windows.Graphics.Display.DisplayInformation.GetForCurrentView().RawPixelsPerViewPixel;
    double closest = possibleRatios.Aggregate((x,y) => Math.Abs(x-ratio) < Math.Abs(y-ratio) ? x : y);
    string imageName = "image.scale-" + (int(closest * 100)).ToString() + ".png";
