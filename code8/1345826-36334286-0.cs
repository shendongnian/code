	class Program
	{
		public static void Main(string[] args)
		{
			var listA = new List<Product>();
			
			var listB = new List<Product>();
			
			listA.Add(new Product() {Id = 1, Name = "Hair Curling Tongs"});
			listA.Add(new Product() {Id = 2, Name = "Toys"});
			listA.Add(new Product() {Id = 3, Name = "Coffee"});
			
			listB.Add(new Product() {Id = 3, Name = "Dress"});
			listB.Add(new Product() {Id = 4, Name = "Handbag"});
			
			var results = listA.Union(listB).Distinct(new EqualityComparer()).ToList();
			
			foreach(var result in results)
			{
				Console.WriteLine("{0} ----- {1}", result.Id, result.Name);
			}
			
			// TODO: Implement Functionality Here
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
	
	class Product{
		public int Id{get; set;}
		public string Name {get; set;}
	}
	
	class EqualityComparer: IEqualityComparer<Product> {
		
		public bool Equals(Product p1, Product p2) {
			return p1.Id == p2.Id;
		}
		
		public int GetHashCode(Product p){
			return p.Id;
		}
	}
}
