     SortedList<Key,string> collection = new SortedList<Key, string>();
            collection.Add(new Key { Type = 2 }, "alpha");
            collection.Add(new Key { Type = 1 }, "beta");
            collection.Add(new Key { Type = 3 }, "delta");
            foreach (string str in collection.Values)
            {
                Console.WriteLine(str);
            }
