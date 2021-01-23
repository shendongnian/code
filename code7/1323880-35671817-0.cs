            List<string[]> p1 = new List<string[]>();
            p1.Add(new String[] { "a", "b" });
            List<string[]> p2 = new List<string[]>();
            p2.Add(new String[] { "c", "d" });
            p2.Add(new String[] { "e", "f" });
            // will contain 6 string items: a, b, c, d, e, f
            var result = p1.Concat(p2).SelectMany(s => s).ToList();
