    enum Fruit
    {
        Apple = 0,
        Banana = 1,
        Orange = 2
    }
    enum Vegetable
    {
        Tomato = 0,
        Carrot = 1,
        Celery = 2
    }
    object GetEnum()
    {
        // for example
        return Fruit.Banana;
    }
    ...
    
    var myEnum = GetEnum();
    Vegetable veg = Vegetable.Carrot;
    
    if ((int)myEnum == (int)veg)
    {
        Console.Write("SAME");
    }
