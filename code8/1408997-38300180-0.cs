    // Create some null data point with integer value
    DataPoint nulldp1 = new DataPoint();
    nulldp1.SetValueXY(1, 0);
    
    DataPoint nulldp2 = new DataPoint();
    nulldp2.SetValueXY(2, 0);
    
    chart.Series[yield.Loss].Points.Add(nulldp1);
    chart.Series[yield.Loss].Points.Add(nulldp2);
    
    
    // Plotting the chart
    double index = 0.5;
    foreach (var item in items)
    {
        // The data point for each series
        DataPoint dp = new DataPoint();
        dp.XValue = index;
        dp.SetValueY(item.Percentage);
    
        chart.Series[item.Name].Points.Add(dp);
    
        index++;
    }
