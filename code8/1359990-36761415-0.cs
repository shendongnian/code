    public static void Repeater(int count, Action action)
    {
        for (int i = 0; i < count; i++)
            action();
    }
    
    //Use it like this
    Repeater(10, Method_One);
