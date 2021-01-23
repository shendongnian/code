            var list1 = Enumerable.Range(0, 10000000).ToList();
            var list2 = Enumerable.Range(10000000, 10000000).ToList();
            var list3 = Enumerable.Range(20000000, 10000000).ToList();
            var lists = new List<List<int>> { list1, list2, list3 };
            var timer = new Stopwatch();            
            timer.Start();
            
            var items = GetPageItems(lists, 6, 1000000).ToList();
            var count = items.Count();
            
            timer.Stop();
