    private void Process(AreaSeries arSer) {
        ...
    }
    private void Process(CandleStickSeries csSer) {
        ...
    }
    private void Process(HighLowSeries hlSer) {
        ...
    }
    ...
    while(true) {
        System.Threading.Thread.Sleep(1000);
        Process((dynamic)PlotModel.Series.First());
        //      ^^^^^^^^^
    }
