    double dbl = AssignValue<double>("Hello");
    
    public T AssignValue<T>(object ValueToAssign)
    {
        Type type = typeof(T);
        switch(type)
        {
            ....
        }
    }
