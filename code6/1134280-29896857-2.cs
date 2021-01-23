    DateTime time = DateTime.ParseExact(textBox1.Text, "yyyy-MM-dd HH:mm", System.Globalization.DateTimeFormatInfo.InvariantInfo);
    const double valueToAdd = 1;
            
    ChartItem item = chartItems.SingleOrDefault(x => x.Time == time);
    if (item == null) // No previous time in series
    {   
        item = new ChartItem(time, valueToAdd);
        chartItems.Add(item);
    }
    else // Add to previous time
        item.Value += valueToAdd;
    chart1.Series[0].Points.DataBind(chartItems, "Time", "Value", ""); // Update chart
