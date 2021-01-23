          foreach (KeyValuePair<string, values> value1 in chartStats)
            {
                DataPoint dp = new DataPoint();
                dp.AxisLabel = value1.Key;
                
                dp.YValues = new double[] { value1.Value.percent };
                chart1.Series[0].Points.Add(dp);
                chart1.ChartAreas[0].AxisX.Interval = 1;
                DataPoint dp1 = new DataPoint();
                //dp1.AxisLabel = "a";
                dp1.YValues = new double[] { (double)value1.Value.angleSumHits };
                chart1.Series[1].Points.Add(dp1);
             
               }
