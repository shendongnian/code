    int[] A = {99, 15, 66, 75, 80, 5, 88, 5};
	List<Tuple<string, int>> list = new List<Tuple<string, int>>();
	list.Add(new Tuple<string, int>(A[0].ToString(),A[0]));
	for(int i = 1; i < A.Length; i++)
	{
		var newlist = new List<Tuple<string, int>>();
		list.ForEach(l=>newlist.Add(new Tuple<string, int>(l.Item1 + " " + A[i],l.Item2 + A[i])));
		list.Add(new Tuple<string, int>(A[i].ToString(),A[i]));
		list.AddRange(newlist);
	}
	
	list.Where(l =>l.Item2 >= 100).OrderBy(o=>o.Item2).Dump();
