    public string Test(string t)
    {
        var x = someoutcome();
        // define d here to have it available for return at the end of method block
        // note: you have to provide default value to return in case one of following "if" conditions are not true
        string d == null;
        if(x != null)
        {
            var b = "A string to be returned" + t;
            var c = anothermethod();
            if(c.GetType() == typeof(string))
                d = "Hurray c and b are strings" + b;
        }
        return d;
    }
