    public string Test(string t)
    {
        var x = someoutcome();
    
        //test to be sure of outcome
        if(x != null)
        {
            var b = "A string to be returned" + t;
            var c = anothermethod();
            if(typeof(c) == string)
            {
                return "Hurray c and b are strings" + b;
            }
        }
        return string.Empty;
    }
