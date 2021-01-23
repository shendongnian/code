        private IEnumerable<int> GoNuts(IEnumerable<int> items)
        {
		    var originalItems = items;
            items = items.Select(item =>
            {
                Console.WriteLine("Select item = {0}", item);
                return GetFirst(originalItems, item);
            });
            return items;
        }
