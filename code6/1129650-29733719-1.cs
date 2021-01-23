    Dictionary<DateTime, Tuple<string, Double, Double>> testDic = new Dictionary<DateTime, Tuple<string, Double, Double>>();
        for (int i = 0; i < testDic.Count; i++)
        {
            var item = testDic.ElementAt(i);
            Chart1.Series["Series1"].Points.DataBindXY(Convert.ToDateTime(item.Key).ToString("dd MMM yyyy"), Convert.ToString(item.Value.Item2));
            Chart1.Series["Series1"].ToolTip = item.Value.Item1;
        }
                    
