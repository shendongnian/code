    void colorSeries(Chart chart)
    {
        List<Color> seriescolors = new List<Color> 
           { Color.Khaki, Color.Brown, Color.CornflowerBlue,
             Color.DarkCyan, Color.ForestGreen, Color.Gold, Color.HotPink, Color.Indigo};
        int co = 0;
        foreach (Series s in chart.Series)
            if (s.Enabled) s.Color = seriescolors[co++];
    }
