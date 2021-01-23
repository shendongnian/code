    var l = new List<int> {1000, 1000, 1000};
    var gr = from i in l
         group i by new
            {
                j = i
            }
            into g1
            select new
            {
                Id = g1.Key.j
            };
    var count = gr.Count(); // <- count is 1!
