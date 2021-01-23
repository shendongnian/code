    void Main()
    {
	var list = new List<Entity>{
		new Entity{TempDate = "25.10.2015", SomeData="data1"},
		new Entity{TempDate = "20.10.2015", SomeData="data2"},
		new Entity{TempDate = "26.10.2015", SomeData="data3"},
		new Entity{TempDate = "18.10.2015", SomeData="data4"}};
		
	list.Dump("Original");
	
	list.OrderBy(x => x.DateTimeParsed).Dump("Sorted");
    }
    public struct Entity
    {
	public string TempDate {get; set;}
	public DateTime DateTimeParsed{ get{ return DateTime.ParseExact(TempDate, "dd.mm.yyyy",CultureInfo.InvariantCulture); }}
	
	public string SomeData {get; set;}
    }
