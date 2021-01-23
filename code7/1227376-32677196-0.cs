    public MyClassType MyClass
    {
        get
        {
            //Don't even ask.
            return (MyClassType)App.Current.GetType().GetProperty("MyClass").GetValue(App.Current);
        }
    }
