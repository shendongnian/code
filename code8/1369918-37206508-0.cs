    public static UIColor GetColor(int[] rgba)
    {
        if (rgba.Length == 4)
            return UIColor.FromRGBA(rgba[0], rgba[1], rgba[2], rgba[3]);
        else return UIColor.Black;
    }
