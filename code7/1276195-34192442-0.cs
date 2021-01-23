	List<string> s=new List<string>();
	s.Add("one");
	List<string> p=new List<string>();
	p.Add("one");
	
	string result = "";
	
	if (s.SequenceEqual(p))
	{
	    result = "equal";
	}
	else
	{
	    result = "unequal";
	}
