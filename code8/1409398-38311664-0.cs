    String str = "123456789";
    
    int page = 0;
    int pageSize = 7; // change it to 70;
    while(true)
    {
        string subStr = new string(str.Skip(page * pageSize ).Take(7).ToArray());
        Console.WriteLine(subStr);
        if (page * pageSize > str.Length)
            break;
    
        page++;
    }
