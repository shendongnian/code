        var rnd = new Random();
        var list = new ArrayList();
        while (list.Count <= 6)
        {
            int t = rnd.Next(1, 49);
            while (list.Contains(t))
            {
                t = rnd.Next(1, 49);
            }
            list.Add(t);
        }
