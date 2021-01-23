        public ViewResult List(string category)
        {
            var viewModel = new MetricsListViewModel 
            {
                Metrics = repository.Metrics
                    .Select(p => new MatricListViewModel(p.cs_username)
					.ToList()
            };
        }
