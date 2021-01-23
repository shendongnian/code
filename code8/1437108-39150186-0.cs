    void computation(A base_class)
    {
        var b = base_class as B;
        if (b != null)
        {
            //Do some stuff with temp
        }
        var c = base_class as C;
        if (c != null)
        {
            //Do some stuff with (base_class as C)
        }
    }
