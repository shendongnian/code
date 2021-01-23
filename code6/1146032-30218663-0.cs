            string[] strings = new[] { "1", "2", "2", "2", "1" };
            List<int> items = new List<int>();
            
            for (int i = 0; i < strings.Length; i++)
            {
                int item = int.Parse(strings[i]);
                if (!items.Contains(item))
                    items.Add(item);
            }
