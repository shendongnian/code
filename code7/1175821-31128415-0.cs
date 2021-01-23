	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;
	namespace ConsoleApplication26
	{
		class Program
		{
			static void Main(string[] args)
			{
				private1 p1 = new private1();
				private2 p2 = p1.foo();
				Console.WriteLine(p2.Value);
				Console.ReadLine();
			}
			private class private1
			{
				public private2 foo()
				{
					private2 p2 = new private2("I was created inside a different private class!");
					return p2;
				}
			}
			private class private2
			{
				private string _value;
				public string Value
				{
					get { return _value; }
				}
				public private2(string value)
				{
					this._value = value;
				}
			}
		}
	}
