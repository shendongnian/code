    Dictionary<DateTime, Tuple<string, Double, Double>> testDic = new Dictionary<DateTime, Tuple<string, Double, Double>>();
        var ok = from ele in testDic
                 select ele.Value.Item2;
        var sys = from ele in testDic
                  select ele.Value.Item1;
        for (int min = 0; min < testDic.Count; min++)
        {
            Chart1.Series["Series1"].Points.DataBindXY(testDic.Keys, ok.ToArray());
            Chart1.Series["Series1"].ToolTip =  Yvariable + " at " + Xvariable;
        }
                    
