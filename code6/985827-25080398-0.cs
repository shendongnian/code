    List<string> categories = new List<string> {"Bags", "Luggage", "Travel", "Other"};
	Product p = new Product();
	p.Name = "MyProduct";
	p.Keywords = "Luggage";
	p.Description = "Some product";
	Product p1 = new Product();
	p1.Name = "MyProduct";
	p1.Keywords = "Airport";
	p1.Description = "Luggage";
	Product p2 = new Product();
	p2.Name = "MyProduct";
	p2.Keywords = "Abc";
	p2.Description = "Other";
	List<Product> products = new List<Product> {p, p1, p2};
    
    // Create a dictionary with a list of products for each category.
	Dictionary<string, List<Product>> categorisedProducts = new Dictionary<string, List<Product>>();
	foreach(string category in categories)
	{
		categorisedProducts.Add(category, new List<Product>());
	}
    
    // Categorise the products.
	categories.ForEach(category => products.ForEach(product =>
	{
		string productString = product.Description + product.Keywords + product.Name;
		if (productString.Contains(category))
		{
			categorisedProducts[category].Add(product);
		}
	}));
    // Display all products with their category.
	foreach (string s in categorisedProducts.Keys)
	{
		foreach (Product prod in categorisedProducts[s])
		{
			Console.WriteLine("Name: " + prod.Name);
			Console.WriteLine("Description: " + prod.Description);
			Console.WriteLine("Keywords: " + prod.Keywords);
			Console.WriteLine("Category: " + s);
		}
	}
	Console.Read();
