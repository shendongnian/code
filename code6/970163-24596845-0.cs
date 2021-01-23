	using System;
	using System.Runtime.Remoting;
	namespace ConsoleApplication2
	{
		class Program
		{
			static void Main(string[] args)
			{
				ObjectHandle handleA = Activator.CreateInstance("ConsoleApplication2", "ConsoleApplication2.A");
				dynamic instanceA = handleA.Unwrap();
				instanceA.A1 = 1;
				instanceA.b1 = "11";
				Console.WriteLine(instanceA.A1);
				Console.WriteLine(instanceA.b1);
			}
		}
		public class A
		{
			public int A1 { get; set; }
			public string b1 { get; set; }
		}
	}
