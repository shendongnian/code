	interface ICommon
	{
		DateTime DT { get; }
		void Print();
	}
	class ClassA : ICommon
	{
		public DateTime DT { get; set; }
		public void Print() { Console.WriteLine("A " + DT); }
	}
	class ClassB : ICommon
	{
		public DateTime DT { get; set; }
		public void Print() { Console.WriteLine("B " + DT); }
	}
		
	public static void Main()
	{
		var listA = new List<ClassA> { new ClassA() { DT = DateTime.Now.AddDays(-1) }, new ClassA() { DT = DateTime.Now.AddDays(-3) }};
		var listB = new List<ClassB> { new ClassB() { DT = DateTime.Now.AddDays(-2) }, new ClassB() { DT = DateTime.Now.AddDays(-4) }};
		
        var orderedResult = listA.Cast<ICommon>()
                                 .Concat(listB.Cast<ICommon>())
                                 .OrderBy(q => q.DT)
		foreach (var obj in orderedResult)
			obj.Print();
	}
