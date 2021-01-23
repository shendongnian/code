        private void Test()
        {
    
            var items = GetListItems(); 
            var po = new ParallelOptions();
    
            for (; ; )
                {
                    Parallel.ForEach(items, po, (it) =>
                    {
                        it.Date = DateTime.Now; // Add breakpoint here.
                    });
    
                    var testList = items.ToList();
                }
        }
    
        private IEnumerable<GroupSettings> GetListItems()
        {
            for (int i = 0; i < 3; i++)
                {
                    yield return new GroupSettings(new Random().Next(), Guid.NewGuid() + "@gmail.com") { Date = DateTime.Now };
                }
        }
