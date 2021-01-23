        public IList<int> A()
        {
            var AcctLst = new List<int> { 0, 2, 5, 8 };
            if (true)
            {
                Task<IList<int>> task = saveCaseSearch();
                Task t = task.ContinueWith(
                        r => { Console.WriteLine(r.Result[0]); }
                 );
            }
            Console.WriteLine("After the async call");
            return AcctLst;
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
