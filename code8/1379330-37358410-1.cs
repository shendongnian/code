    seriesIndex = 0;
    Chart.Tools.Add(new MarksTip());
    foreach (var seriesData in seriesDataList)
    {
        var series = new Box()
    
        series.UseCustomValues = true;
        //Other series appearance stuff
    
        series.Add(seriesIndex, seriesData);
    
        series.Title = "tooltip text";
        series.GetSeriesMark += (s, args) =>
        {
            args.MarkText = s.Title;
        };
        series.Marks.Visible = false;
        Chart.Series.Add(series);    
        seriesIndex++;
    }
