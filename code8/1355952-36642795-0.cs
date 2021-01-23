    public static void WhenTrue(this bool condition, Action action)
    {
        if (action == null)
            throw new ArgumentNullException("action");
        if (condition)
            action();
    }
