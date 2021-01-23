    public static void Set3Variables<T>(params Action<T>[] actions)
        where T : new()
    {
        foreach (var action in actions)
            action(new T());
    }
