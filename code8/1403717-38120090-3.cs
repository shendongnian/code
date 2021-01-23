    var newDimensions = GetImageDimensions(...);
    // We need to detect whether to resize or to crop
    bool mustCrop = newDimensions.Item3;
    // Initialize your SOURCE coordinates
    int x = 0;
    int y = 0;
    int w = image.Width;
    int h = image.Height;
    // Adjust if we want to crop
    if (mustCrop)
    {
        x = (image.Width - newDimensions.Item1) / 2;
        y = (image.Height - newDimensions.Item2) / 2;
        w = newDimensions.Item1;
        h = newDimensions.Item2;
    }
