    public MyClass(object par)
    {
        if (par.GetType() == typeof(double))
        {
            // do double stuff
        }
        if (par.GetType() == typeof(string))
        {
            // do string stuff
        }
        else
        {
           // unexpected - fail somehow, i.e. throw ...
        }
    }
