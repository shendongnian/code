    public static T Pipe<T>(Func<T> action)
    {
        Console.WriteLine("Entering pipe");
        if (someCondition)
            action();
        else
            // do something else
    }
