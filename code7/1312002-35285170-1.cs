    object[] pointnum = new object[majorArticleCount.Count];
                pointnum = majorArticleCount.Cast<object>().ToArray();
                Highcharts chartArticleCount = new Highcharts("chart1")
                          .SetXAxis(new XAxis { Categories = majors })
                          .SetYAxis(new YAxis { Title = new YAxisTitle { Text = "تعداد مقالات" } })
                          .SetSeries(new Series { Data = new Data(pointnum.ToArray()), Name = "محور های همایش" })
                          .SetTitle(new Title { Text = "" })
                          .InitChart(new Chart { DefaultSeriesType = ChartTypes.Column });
