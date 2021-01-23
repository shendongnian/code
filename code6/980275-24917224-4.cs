    //1º
    foreach (var item in result.Elements())
    {
        Console.WriteLine(item.Name + " = " + item.Value);
    }
    
    //2º - will print the element
    Console.WriteLine(result);
