    void Main()
    {
	List<string> list1 = new List<string>();
	List<string> list2 = new List<string>();
	
	list1.Add("a");
	list1.Add("b");
	list1.Add("b");
	list1.Add("c");
	list1.Add("b");
	list2.Add("b");
	list2.Add("d");
	list2.Add("c");
    var resultList=	temp(list2,list1);
    }
    List<string> temp(List<string> x,List<string> y)
    {
	foreach(var value in y)
	{
		x.Remove((x.Where(z=>z == value).SelectMany(g=>g.Take(1).DefaultIfEmpty(g.First())).FirstOrDefault()).ToString());
	}
	return x;
    }
