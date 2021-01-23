    const int intervalMinutes = 15;
    const int numIntervals = 24 * (60/intervalMinutes);
    for(int i = 0; i < numIntervals; ++i)
    {
        double sum = 0d;
        
        //for every series in the chart collection sum the yvalues at the specified 
        foreach (Series s in dataSeries)
        {
            sum += s.Points[i].YValues[0];
        }
        DataPoint dp = new DataPoint();
        //Add a new yvalue to the datapoint for the summed series's
        
        //And I will get an error in this one as well
        dp.XValue = dataSeries[0].Points[i].XValue;
        
        dp.YValues[0] = sum;
        sumSeries.Points.Add(dp);
    }
