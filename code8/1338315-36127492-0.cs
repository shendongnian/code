    public object[][] bloop (string[] bstr)
    {
        var numbers = new List<int>();
        var strings = new List<string>();
        var result = new object[2][];
    
        foreach(var str in bstr)
        {
            int number = 0;
            if(int.TryParse(str, out number))
            {
                numbers.Add(number);
            }
            else
            {
                strings.Add(str);
            }
        }
    
        result[0] = strings.ToArray();
        result[1] = numbers.ToArray();
    
        return result;
    }
