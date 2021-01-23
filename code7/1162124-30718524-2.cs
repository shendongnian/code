    @{
        ViewBag.Title = "Sample";
    }
    @using DotNet.Highcharts;
    @using DotNet.Highcharts.Options;
    @using DotNet.Highcharts.Helpers;
        
    <script src="~/Scripts/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="~/Scripts/Highcharts-4.0.1/js/highcharts.js" type="text/javascript"></script>
    @{
        Highcharts chrt = new Highcharts("chart")
                        .SetXAxis(new XAxis { Categories = new[] { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" } })
                        .SetYAxis(new YAxis { Title = new YAxisTitle { Text = "Sales" } })
                        .SetSeries(new Series { Data = new Data(new object[] { 20, 30, 40, 50, 20, 60, 14, 72, 30, 35, 10, 20 }), Name = "Sales" })
                        .SetTitle(new Title { Text = "Sales Data" })
                        .InitChart(new DotNet.Highcharts.Options.Chart { DefaultSeriesType = DotNet.Highcharts.Enums.ChartTypes.Column });
    }
    
    @(chrt)
