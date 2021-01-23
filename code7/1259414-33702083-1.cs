    var restWords = new string[] { "cotton", "spiderman" };
    var orReg = new System.Text.RegularExpressions.Regex(string.Join("|", restWords));
    filter &= builder.Regex("Name", BsonRegularExpression.Create(orReg));
    
    List<Product> filteredList = products.Find(filter).ToListAsync().Result;
