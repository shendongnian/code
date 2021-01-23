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
        // runs sync and in the end returns Task that is never actually fired
        public async Task<IList<int>> saveCaseSearch()
        {
            Thread.Sleep(5000);
            return new List<int>() { 10, 12, 16 };
        }
