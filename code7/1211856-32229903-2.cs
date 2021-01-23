	var target = new MyClass();
	target.MyValues = new List<MyOtherClass>();
	
	var i = new MyOtherClass();
	
	i.Start = new DateTimeValue();
	i.Start.DateTime = new DateTime(2015, 08, 23);
	
	i.End.DateTime = new DateTime(2015, 08, 23);
	
	target.MyValues.Add(i);
	
