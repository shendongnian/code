        public ViewResult List(string category)
        {
            var viewModel = new MetricsListViewModel 
            {
                Metrics = repository.Metrics
                    .Select(p => p.cs_username)
					.ToList()
            };
        }
