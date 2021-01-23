	class Data
	{
		public int y { get; set; }
		public string myData { get; set; }
	}
	List<Data> list = new List<Data>
    {
	   new Data() { y = 3, myData = "firstPoint"},
	   new Data() { y = 7, myData = "secondPoint"},
	   new Data() { y = 1, myData = "thirdPoint"},
    };
	string json = JsonConvert.SerializeObject(list);
