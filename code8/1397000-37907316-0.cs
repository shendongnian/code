		private static void Test(IEnumerable<string> names)
		{
			using (var context = new NORTHWNDEntities())
			{
				foreach (var product in context.Products.Where(product => names.Any(name => product.ProductName.Contains(name))))
				{
					Console.WriteLine(product.ProductName);
				}
			}
			Console.ReadLine();
		}
