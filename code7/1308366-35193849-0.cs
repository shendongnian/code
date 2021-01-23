    protected void RequestChart_Customize(object sender, EventArgs e)
            {
                //hide label value if zero
                foreach (System.Web.UI.DataVisualization.Charting.Series series in RequestChart.Series)
                {
                    foreach (System.Web.UI.DataVisualization.Charting.DataPoint point in series.Points)
                    {
                        if (point.YValues.Length > 0 && (double)point.YValues.GetValue(0) == 0)
                        {
                            point.IsValueShownAsLabel = false;
                        }
                    }
                }
            }
