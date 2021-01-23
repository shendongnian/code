    public static void Invoke<T>(this T c, Action<T> action) where T : Control
    {
        if (c.Dispatcher.CheckAccess()))
            control.Dispatcher.Invoke(...)
        else
            action(c);
    }
