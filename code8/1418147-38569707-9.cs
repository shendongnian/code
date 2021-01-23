        seriesSet.Add(new DotNet.Highcharts.Options.Series
        {
            Type = chartType,
            //Name = "Targeted_" + Convert.ToString(tarCount.Count()),                
            Name = "Targeted",
            Data = nnew DotNet.Highcharts.Helpers.Data((object[])targeted.Cast<object[]>()
                                                 .Select(item => (object)item[0])),
            Color = tarColor,
            PlotOptionsColumn = new DotNet.Highcharts.Options.PlotOptionsColumn
            {
                PointPadding = -0.1
            }, 
             
        });
