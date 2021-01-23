    IDictionary<string, object> obj = new ExpandoObject();
    var propName = "Product";
    obj[propName] = "Pie"
    Console.WriteLine("Let's print!: " + obj[propName]);
    // Verify it's working
    Console.WriteLine("Let's print again!: " + ((dynamic)obj).Product);
