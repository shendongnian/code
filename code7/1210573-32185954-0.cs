	using System;
	using System.Linq;
	using System.Text;
	namespace ConsoleApplication3
	{
		class Program
		{
			static void Main(string[] args)
			{
				Func<double, string> toFixedWidth = (d) => { 
					return string.Format("{0:00000000.00;-0000000.00}", d); 
				};
				foreach (var d in new double[] { 1.2, 0.2, -0.2, 12, 0, -0, 12.555 })
				{
					Console.WriteLine(toFixedWidth(d));
				}
			}
		}
	}
----------
	00000001,20
	00000000,20
	-0000000,20
	00000012,00
	00000000,00
	00000000,00
	00000012,56
	Press any key to continue . . .
