    public ActionResult MyChart()
    {
        var vm= new MyChartData { Name = "MyChartTitle",Series = new List<ChartSeriesData>()};
        vm.Series.Add(new ChartSeriesData
        {
            Name = "View",
            XValues = new[] { "Monday", "Tuesday", "Wendesday", "Thursday", "Friday" },
            YValues = new[] { "2", "6", "4", "5", "3" }}
        );
        vm.Series.Add(new ChartSeriesData
        {
            Name = "Downloads",
            XValues = new[] { "Monday", "Tuesday", "Wendesday", "Thursday", "Friday" },
            YValues = new[] { "1", "2", "6", "5", "3" }
        });
        return View(vm);
    }
