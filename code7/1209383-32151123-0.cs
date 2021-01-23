    public void myClass(Type x)
    {
        if (x == typeof(int))
        {
            Console.WriteLine("int");
        }
        else if (x == typeof(bool))
        {
            Console.WriteLine("bool");
        }
        else if (x == typeof(string))
        {
            Console.WriteLine("string");
        }
        //additional Type tests can go here
        else Console.WriteLine("Invalid type");
    }
