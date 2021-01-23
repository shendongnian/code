        private int GetFirst(IEnumerable<int> items, int foo)
        {
            Console.WriteLine("GetFirst {0}", foo);
            var rslt = items.First(i => i == foo);
            Console.WriteLine("GetFirst returns {0}", rslt);
            return rslt;
        }
        private IEnumerable<int> GoNuts(IEnumerable<int> items)
        {
            items = items.Select(item =>
            {
                Console.WriteLine("Select item = {0}", item);
                return GetFirst(items, item);
            });
            return items;
        }
