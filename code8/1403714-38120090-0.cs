    public static Tuple<int, int, bool> GetImageDimensions(int originalWidth, int originalHeight, int? width, int? height)
    {
        double widthRatio = (double)originalHeight / (double)originalWidth;
        double heighthRatio = (double)originalWidth / (double)originalHeight;
        int newWidth = originalWidth;
        int newHeight = originalHeight;
        bool cropping = false;
        if (width.HasValue && !height.HasValue && width.Value <= originalWidth)
        {
            newWidth = width.Value;
            newHeight = (int)(width.Value * widthRatio);
        }
        else if (!width.HasValue && height.HasValue && height.Value <= originalHeight)
        {
            newHeight = height.Value;
            newWidth = (int)(height.Value * heighthRatio);
        }
        else
        {
            cropping = true;
        }
        return new Tuple<int, int>(newWidth, newHeight, cropping);
    }
