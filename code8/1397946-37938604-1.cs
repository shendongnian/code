	using System.Collections.Generic;
	using System.Linq;
	namespace StackOverflowAnswer
	{
		public struct objA
		{
			public int foo1 { get; set; }
			public string foo2 { get; set; }
			public bool foo3 { get; set; }
		}
		class Program
		{
			static void Main()
			{
				List<objA> name1 = new List<objA>() { new objA { foo1 = 1, foo2 = "bb", foo3 = true }, new objA { foo1 = 2, foo2 = "cc", foo3 = false } };
				List<objA> name2 = new List<objA>();
				List<objA> name3 = new List<objA>() { new objA { foo1 = 1, foo2 = "bb", foo3 = true } };
				List<objA> name4 = new List<objA>() { new objA { foo1 = 1, foo2 = "bb", foo3 = true }, new objA { foo1 = 2, foo2 = "cc", foo3 = false } };
				List<objA> name5 = new List<objA>() { new objA { foo1 = 1, foo2 = "bb", foo3 = true } };
				List<objA> x = name1
					//.Intersect(name2)
					.Intersect(name3)
					.Intersect(name4)
					.Intersect(name5)
					.ToList();
			}
		}
	}
