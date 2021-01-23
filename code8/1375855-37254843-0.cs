    List<string> list = new List<string>();
            list.Add("Dubai");
            list.Add("Sarjah");
            list.Add("Dubai");
            list.Add("Lahor");
            list.Add("Dubai");
            list.Add("Sarjah");
            list.Add("Sarjah");
            
            int most = list.GroupBy(i => i).OrderByDescending(grp => grp.Count())
                .Select(grp => grp.Count()).First();
            IEnumerable<string> mostVal = list.GroupBy(i => i).OrderByDescending(grp => grp.Count())
                .Where(grp => grp.Count() >= most)
                .Select(grp => grp.Key) ;
