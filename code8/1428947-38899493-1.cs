    public static T Pipe<T>(Func<T> action)
    {
        Console.WriteLine("Entering pipe");
        if (someCondition)
            return action();
        else
        {
            // do something else; but you still need to return something
            return default(T);
        }
    }
