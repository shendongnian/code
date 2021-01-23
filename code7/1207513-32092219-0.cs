    Bitmap loadedImage = new Bitmap(filename); 
    var newImage = new Bitmap(loadedImage.Width, loadedImage.Height);
    // don't create variables here...
    Parallel.For(0, loadedImage.Height, (i) =>
        {
            for (int j = 0; j < loadedImage.Width; j++)
            {
                // but here -- that's better for a lot of reasons.
                var color = loadedImage.GetPixel(j, i);
                var r = color.R;
                var g = color.G;
                var b = color.B;
                newImage.SetPixel(j, i, Color.FromArgb(r, g, b));                    
            }
        });
