    public static Color medianColor(List<Color> cols)
    {
        int c = cols.Count;
        return Color.FromArgb(cols.Sum(x => x.A) / c, cols.Sum(x => x.R) / c,
            cols.Sum(x => x.G) / c, cols.Sum(x => x.B) / c);
    }
