    public void M<T>(T value) 
    {
        if (typeof(T).IsAssignableFrom(typeof(double)))
            Console.Write("It's a double");  
    }
