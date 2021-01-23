 	List<List<string>> nestedList = new List<List<string>>();
    nestedList.Add(new List<string> { "test1" } );
    nestedList.Add(new List<string> { "test2" } );
    nestedList.Add(new List<string> { "test3" } );
		
	var tocheck="test3";
		
	var item = nestedList.Where(s=>s.Any(d=>d==tocheck)).FirstOrDefault();
    if(item!=null)
	{
	   var itemIndex=nestedList.IndexOf(item);
	  // Console.WriteLine(itemIndex);
	}
