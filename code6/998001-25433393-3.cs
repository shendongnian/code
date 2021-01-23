    public ViewResult List(string category)
    {
        var viewModel = new MetricsListViewModel 
        {
            Metrics = repository.Metrics.ToList()
        };
    }
