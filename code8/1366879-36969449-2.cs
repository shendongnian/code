	using System;
	using System.Linq;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
						
	public class Program
	{
		public enum StatusType
		{
			[Display(Name = "Recuiting", Order = 0)]
			Recruiting,
			[Display(Name = "Completed", Order = 2)]
			Completed,
			[Display(Name = "Active and not Recruiting", Order = 1)]
			ActiveAndNotRecruiting
		}
		
		
		public static void Main()
		{
			var list = new List<SomeClass>
			{
				new SomeClass{ Status = StatusType.Recruiting, Id = 1, Name = "Abraham"},
				new SomeClass{ Status = StatusType.Completed, Id = 2, Name = "Ben"},
				new SomeClass{ Status = StatusType.ActiveAndNotRecruiting, Id = 3, Name = "Carl"},
				new SomeClass{ Status = StatusType.Completed, Id = 4, Name = "Dan"},
				new SomeClass{ Status = StatusType.Recruiting, Id = 5, Name = "Erin"}
			};
			
			PrintList(list);
			
			Console.WriteLine("-");
			
			var sorted = list
				.OrderBy(cs => cs.Status.ToDisplay().Order)
				.ToList();
			
			
			PrintList(sorted);
	
		}
	
		public static void PrintList(IEnumerable<SomeClass> list)
		{
			foreach(var sc in list) Console.WriteLine("{0}, {1} is {2}", sc.Id, sc.Name, sc.Status.ToDisplay().Name);
		}
		
		public class SomeClass
		{
			public int Id { get; set; }
			public string Name { get; set; }
			public StatusType Status { get; set; }	
		}
	}
	
	public static class EnumExtensions
	{
		public static DisplayAttribute ToDisplay(this Enum enumValue) 
		{
			return enumValue.GetType()
				.GetMember(enumValue.ToString())
				.First()
				.GetCustomAttributes(false)
				.Where(a => a is DisplayAttribute)
				.FirstOrDefault() as DisplayAttribute;
		}
	}
