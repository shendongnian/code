        seriesSet.Add(new DotNet.Highcharts.Options.Series
        {
            Type = chartType,              
            Name = "Targeted",
            Data = new DotNet.Highcharts.Helpers.Data(targeted.Select(item => (object)item[0]),
            Color = tarColor,
            PlotOptionsColumn = new DotNet.Highcharts.Options.PlotOptionsColumn
            {
                PointPadding = -0.1
            }, 
             
        });
