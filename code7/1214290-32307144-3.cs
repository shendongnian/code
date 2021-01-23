        public void ArrangeList()
        {
            List<String> data = new List<string>() { "1001A", "1002A", "1003A", 
            "1004A", "1015A", "1016A", "1007A", "1008A", "1009A", "1017A" };
            List<int> data_int = data.Select(a => Convert.ToInt32(a.Substring(0,
            a.Length - 1))).OrderBy(b => b).ToList();
            int initializer = 0, counter = 0;
            int finalizer = 0;
            foreach (var item in data_int)
            {
                if (initializer == 0)
                { initializer = item; continue; }
                else
                {
                    counter++;
                    if (item == initializer + counter)
                        finalizer = item;
                    else
                    {
                        LogListing(initializer, finalizer);
                        initializer = item;
                        finalizer = item;
                        counter = 0;
                    }
                }
            }
            LogListing(initializer, finalizer);
        }
