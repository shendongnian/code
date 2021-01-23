    public static void LinesDown(this ScrollViewer scroll, int lines)
    {
        for (int i = 0; i < lines; i++)
            scroll.LineDown();
    }
