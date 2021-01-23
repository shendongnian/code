 	public class MainClass
	{
		public ObjectId Id { get; set; }
		public string PropOne { get; set; }
		public string PropTwo { get; set; }
		public List<SubClass> subClasses { get; set; }
	}
	public class SubClass
	{
		public string PropThree { get; set; }
	}
	public class MainWithSub
	{
		public ObjectId Id { get; set; }
		public string PropOne { get; set; }
		public string PropTwo { get; set; }
		public string PropThree { get; set; }
	}
