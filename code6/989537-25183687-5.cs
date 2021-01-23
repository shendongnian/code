    bool IsOfMyDerivedClass2_OrMoreDerived(object instance)
    {
        if (instance == null)
            throw new ArgnumentNullException();
        
        return typeof(MyDerivedClass2).IsAssignableFrom(instance.GetType());
    }
