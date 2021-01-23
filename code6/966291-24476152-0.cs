            List<int> a = new List<int>();
            List<int> b = new List<int>();
            for (int i = 0; i < 100; i++)
            {
                b.Add(i);
            }
            List<int> sublist = a.GetRange(20, 10);
            a.AddRange(sublist);
