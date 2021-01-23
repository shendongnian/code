        string abc = "HelloWorld!!1234567true";            
        int y;
        bool z ;
        string x = abc.Substring(0, 12); 
        Int32.TryParse(abc.Substring(12, 7), out y);
        Boolean.TryParse(abc.Substring(19, 4), out z); 
        Console.WriteLine(x);
        Console.WriteLine(y);
        Console.WriteLine(z);
