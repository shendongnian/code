    foreach (var word in restWords)
    {
    	filter &= builder.Regex("Name", BsonRegularExpression.Create(new System.Text.RegularExpressions.Regex(word)));
    }
    
    List<Product> filteredList = products.Find(filter).ToListAsync().Result;
