    class Program
	{
		struct MyStruct
		{
			public string Data { get; set; }
		}
		static void Main(string[] args)
		{
			var list = new List<MyStruct>();
			list.Add(new MyStruct { Data = "A" });
			list.Add(new MyStruct { Data = "B" });
			list.Add(new MyStruct { Data = "C" });
			var arr = new string[] { "a", "b" };
			var result = (from s in list
						  from a in arr
						  where s.Data.Equals(a, StringComparison.InvariantCultureIgnoreCase)
						  select s).ToArray();
		}
	}
