                Highcharts AttritionByReasonBarChart = new Highcharts("AttritionByReasonBarChart")
                            .InitChart(new Chart { DefaultSeriesType = ChartTypes.Column, Height = 400, Width = 860, Style = "margin: '0 auto'" })
                            .SetTitle(new Title { Text = "Attrition by Reason", Style = "font: 'normal 16px Verdana, sans-serif'" })
                            .SetCredits(new Credits { Enabled = false })
                            .SetXAxis(new XAxis
                            {
                                Categories = new[] { "ABD", "IET", "KFJ", "KRT", "OET", "PRT", "NWP", "DFC" },
                                Labels = new XAxisLabels { Rotation = 0 }
                            })
                            .SetYAxis(new YAxis
                            {
                                Title = new YAxisTitle
                                {
                                    Text = "Employment Type",
                                    Align = AxisTitleAligns.Middle
                                }
                            })
                            .SetPlotOptions(new PlotOptions
                            {
                                Column = new PlotOptionsColumn
                                {
                                    PointPadding = -0.2,
                                    DataLabels = new PlotOptionsColumnDataLabels { Enabled = false }
                                }
                            })
                            .SetLegend(new Legend
                            {
                                Layout = Layouts.Vertical,
                                Align = HorizontalAligns.Right,
                                VerticalAlign = VerticalAligns.Middle,
                                Floating = true,
                                BorderWidth = 1,
                                BackgroundColor = new BackColorOrGradient(ColorTranslator.FromHtml("#FFFFFF")),
                                Shadow = true
                            })
                            .SetSeries(
                                new Series
                                {
                                    Name = "Head Count",
                                    Data = new Data(new object[] { 30,10,5,20,5,10,25,15 })
                                });
