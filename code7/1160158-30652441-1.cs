    // Possibly add more generic constraints to T?
    public static Window OpenUserControl<T>(string title)
        where T : new()
    {
        return new Window
        {
            Title = title,
            Content = new T(),
            ShowInTaskbar = false
        };
    }
