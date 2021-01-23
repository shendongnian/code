    public class Program
	{
		public static void Main(string[] args)
		{
			Product A = new Product();
			A.Name = "A";
			A.ProductKeywords = new List<Keyword>() { 
				new Keyword(){Name = "the"},
				new Keyword(){Name = "force"},
				new Keyword(){Name = "awakens"}
			};
			Product B = new Product();
			B.Name = "B";
			B.ProductKeywords = new List<Keyword>() { 
				new Keyword(){Name = "the"},
				new Keyword(){Name = "matrix"}
			};
			List<Product> products = new List<Product>() { A, B	};
			var keywordListTerm = ("the force matrix").Split(' ');
			var query = products.Where(p => !keywordListTerm.Except(p.ProductKeywords.Select(pk => pk.Name)).Any());
			foreach (var item in query) { 
				Console.WriteLine(item.Name);
			}
			Console.ReadKey();
		}
	}
	public class Product {
		public string Name = string.Empty;
		public List<Keyword> ProductKeywords;
	}
	public class Keyword
	{
		public string Name;
	}
