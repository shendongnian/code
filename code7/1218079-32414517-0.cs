        public void formatEnabled(string seriesName, List<string> enabledSeries)
        {
            //color series in by index (0 - blue, 1 - red)
            string blueSeries = enabledSeries.First();
            string redSeries = enabledSeries[enabledSeries.IndexOf(blueSeries) + 1];
            //access all elements in enabledSeries
            for (int enabledIndex = 0; enabledIndex < enabledSeries.Count; ++enabledIndex)
            {
                //access all series in chartVitals
                for (int seriesIndex = 0; seriesIndex < chartVitals.Series.Count; ++seriesIndex)
                {
                    //when there is item in series
                    if (chartVitals.Series[seriesIndex].Points.Count > 0)
                    {
                        string start = "[Start]";
                        //set series type as line
                        chartVitals.Series[seriesIndex].ChartType = SeriesChartType.Line;
                        //apply label to first point of series
                        chartVitals.Series[seriesIndex].Points.First().Label = start;
                        //enable button to mark end
                        //btnOpEnd.Enabled = true;
                    }
                }
            }
            //apply colours to series
            chartVitals.Series[blueSeries].Color = Color.Blue;
            chartVitals.Series[redSeries].Color = Color.Red;
        }
