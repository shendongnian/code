    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    
    JArray products = new JArray();
    foreach (var row in rows_with_checked_column)
    {
    	JObject product = JObject.FromObject(new
    	{
    		ID = row.Cells[1].Value,
    		Name = row.Cells[2].Value,
    		Price = row.Cells[3].Value
    	});
    	products.Add(product);
    }
    
    string json = JsonConvert.SerializeObject(products);
