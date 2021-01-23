    using System;
	using System.Collections.Generic;
	using System.Linq;
	namespace EF_SP
	{
		class Program
		{
			static void Main(string[] args)
			{
				using (var context = new NorthwindEntities())
				{
					var results = context.GetSalesByCategory("Seafood", "1998");
					foreach (var result in results)
						Console.WriteLine("{0} {1}", result.ProductName, result.TotalPurchase);
				}
				Console.WriteLine("Press any key. . .");
				Console.ReadKey(true);
			}
		}
	}
