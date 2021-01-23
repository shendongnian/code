    var chartArea = new System.Windows.Forms.DataVisualization.Charting.ChartArea
                {
                    Name = "ChartArea1",
                    AxisX = new System.Windows.Forms.DataVisualization.Charting.Axis
                    {
                        IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Days
                    }
                };
                //...//
                chart.ChartAreas.Add(chartArea);
