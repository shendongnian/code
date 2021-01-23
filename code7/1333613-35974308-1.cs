    public ActionResult Index()
            {
                object[] desktops = new object[] {17368, 17792, 18235, 18136 };
                var monthsList = new[] { "Feb-15", "Mar-15", "Apr-15", "May-15",};
    
                Highcharts chart = new Highcharts("chart")
             .SetCredits(new Credits { Enabled = false })
             .InitChart(new Chart { DefaultSeriesType = ChartTypes.Column , Height = 190, Width=190})
             .SetTitle(new Title { Text = "Ticket Sales" })
             .SetXAxis(new XAxis { Categories = monthsList, Labels = new XAxisLabels() { } })
             .SetYAxis(new YAxis
             {
                 Min = 0,
                 Title = new YAxisTitle { Text = "Quantity" }
             })
             .SetTooltip(new Tooltip { Formatter = "function() { return ''+  this.series.name +': '+ this.y +''; }" })
             .SetPlotOptions(new PlotOptions { Column = new PlotOptionsColumn{ Color = System.Drawing.Color.Black } })
             .SetSeries(new[]
                     {
                   new Series { Name = "Total", Data = new Data(desktops) }
                      });
    
                return View(chart);
            }
