    var definition = new { Name = "" };
    string json1 = @"{'Name':'James'}";
    var customer1 = JsonConvert.DeserializeAnonymousType(json1, definition);
    
    Console.WriteLine(customer1.Name);
    // James
    
    string json2 = @"{'Name':'Mike'}";
    var customer2 = JsonConvert.DeserializeAnonymousType(json2, definition);
    
    Console.WriteLine(customer2.Name);
    // Mike
