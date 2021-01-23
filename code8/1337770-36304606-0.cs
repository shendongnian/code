    public void SetRangeToTimeFrame(TimeSpan timeFrame)
    {
        // Assuming you have a reference to the data series of type OhlcDataSeries
        int indexMax = dataSeries.XValues.Count - 1;
        // Assuming you know timeframe (one bar = X seconds)
        // If you don;t know this, SciChart tries to calculate it in the 
        // CategoryDateTimeAxis.BarTimeFrame property
        const int timeframe = 900; // for example 900 seconds per bar
        // Calculate the min index to display. Do not go below zero
        int indexMin = Math.Max(indexMax - (timeFrame.TotalSeconds / timeFrame), 0);
        // Set XAxis.VisibleRange equal to the new range
        // OR, Set via binding if you have a property XVisibleRange in ViewModel
        XAxis.VisibleRange = new IndexRange(indexMin, indexMax);
    }
