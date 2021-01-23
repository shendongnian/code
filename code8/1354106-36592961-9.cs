        public IList<int> A()
        {
            ... same code as above
        }
        // notice that we removed `async` keyword here because we just return task.
        public Task<IList<int>> saveCaseSearch()
        {
            return Task.Run<IList<int>>(() =>
            {
                Thread.Sleep(5000);
                return new List<int>() { 10, 12, 16 };
            });
        }
