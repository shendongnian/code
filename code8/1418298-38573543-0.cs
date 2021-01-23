    public void MyMethod(string param)
    {
        var myList = new string[] 
        {
            "example1",
            "example2",
            "example3"
        };
        foreach (var item in myList)
        {
            if (!param.Contains(item)) continue;
        }
        //Do something here
    }
