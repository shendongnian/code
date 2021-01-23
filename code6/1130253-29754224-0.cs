    void Main() {
    	int myObject = getValues("12").Sum(x => Int32.Parse(x.Price));
    	Console.WriteLine (myObject);
    }
    
    List<dynamic> getValues(string something) {
        var item = new { Price = something };
    	IEnumerable<dynamic> items = Enumerable.Repeat<dynamic>(item, 2);
    	return items.ToList();
    }
