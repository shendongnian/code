    if (obj.GetType() == typeof(ClassA))
    {
        var classA = (ClassA)obj;
        Console.WriteLine(classA.WidgetValue);
    }
    else if (obj.GetType() == typeof(ClassB))
    {
        var classB = (ClassB)obj;
        Console.WriteLine(classB.WidgetValue);
    } ...
