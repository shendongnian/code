    int c = 0;
	var list = new List<int>{1,1,1,0,1,1,0,1,1,1,1,0,1,1,1,1,1,1,0,1,1,1,0,1};
	var res = list
        // split in groups and set their numbers
        // c is a captured variable
        .Select(x=>new {Item = x, Subgroup = x==1 ? c : c++})
        // remove zeros
		.Where(x=>x.Item!=0)
        // create groups
		.GroupBy(x=>x.Subgroup)
        // convert to format List<List<int>>
		.Select(gr=>gr.Select(w=>w.Item).ToList())
		.ToList();
