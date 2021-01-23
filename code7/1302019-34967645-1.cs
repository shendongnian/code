    public class Book
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public Store[] Stores { get; set; }
	}
	
	public class Store
	{
		public int Id { get; set; }
		public string Name { get; set; }
	}
	
	public static void Main()
	{
		List<Book> books = new List<Book>();
		var stores = books.SelectMany(x => x.Stores) // flatMap method, returns a collection of stores
                          .Distinct() // only keep different stores
                          .Select(x => // foreach store
                              new { // create a new object
                                  Store = x, // that contains the store
                                  Books = books.Where(book => book.Stores.Contains(x)).ToList() // and a list of each book that is in the store
                                  })
                          .ToList();
		Console.WriteLine(stores);
	}
