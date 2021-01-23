    String str = "123456789";
    
    int page = 0;
    int pageSize = 7; // change this to 70 in your case
    while(true)
    {
        string subStr = new string(str.Skip(page * pageSize).Take(pageSize).ToArray());
        Console.WriteLine(subStr);
                    
    
        page++;
    
        if (page * pageSize >= str.Length)
            break;
    }
