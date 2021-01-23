    public static System.Drawing.Color FromColor(System.ConsoleColor c)
    {
        switch (c)
        {
            case ConsoleColor.DarkYellow:
                return Color.FromArgb(255, 128, 128, 0);
            default:
                return Color.FromName(c.ToString());
        }
    }
