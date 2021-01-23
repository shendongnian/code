    string cont = "[]val1:1val2:0val3:1";
    
    int split = cont.IndexOf("val3:");
    int val3 = Int32.Parse(cont.Substring(split + 5)); // this line successfully convert string to int
    cont = cont.Remove(split);
    Console.WriteLine("Value3: " + val3 + " Content: " + cont);
    split = cont.IndexOf("val2:");
    int val2 = Int32.Parse(cont.Substring(split + 5)); // but this line fails to convert from string to int..
    cont = cont.Remove(split);
    Console.WriteLine("Value2: " + val2 + " Content: " + cont);
    split = cont.IndexOf("val1:");
    int val1 = Int32.Parse(cont.Substring(split + 5));
    cont = cont.Remove(split);
    Console.WriteLine("Value1: " + val1 + " Content: " + cont);
