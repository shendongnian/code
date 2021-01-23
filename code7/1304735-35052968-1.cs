    double dbl = AssignValue<double>("Hello");
    
    public T AssignValue<T>(object valueToAssign)
    {
        Type type = typeof(T);
        switch(type.Name)
        {
            //...
        }
    }
