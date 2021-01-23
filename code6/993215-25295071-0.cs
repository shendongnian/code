    var dict = new List<IEnumerable<Tuple<string, int>>>
    {
    	new Tuple<string, int>[] {
            new Tuple<string, int>("a", 1)
        },
    	new Tuple<string, int>[] {
            new Tuple<string, int>("b", 3),
    		new Tuple<string, int>("a", 2),
    		new Tuple<string, int>("a", 3),
    	},
    	new Tuple<string, int>[] {
            new Tuple<string, int>("b", 2),
        	new Tuple<string, int>("c", 5),
        	new Tuple<string, int>("b", 3),
        	new Tuple<string, int>("c", 2),
        	new Tuple<string, int>("c", 2),
        	new Tuple<string, int>("a", 3)
        }
    };
    var grouped = dict.SelectMany(p => p).GroupBy(p => p.Item1);
    // results in list of int values grouped by string value
    // list of IEnumerable<IGrouping<string, Tuple<string, int>>>
    // a - 1, 2, 3, 3
    // b - 3, 2, 3
    // c - 5, 2, 2
    var dict = grouped.ToDictionary(g => g.Key, g => g.Max(p => p.Item2));
    // results in simple dictionary: a - 3, b - 3, c - 5
