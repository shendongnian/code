    public void Linq102() 
    { 
  
    string[] categories = new string[]{  
        "Beverages",   
        "Condiments",   
        "Vegetables",   
        "Dairy Products",   
        "Seafood" };  
  
    List<Product> products = GetProductList(); 
  
    var q = 
        from c in categories 
        join p in products on c equals p.Category 
        select new { Category = c, p.ProductName }; 
 
    foreach (var v in q) 
    { 
        Console.WriteLine(v.ProductName + ": " + v.Category);  
    } 
    }
