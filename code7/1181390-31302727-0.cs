    public static void SendMessage<T>(string queuName, T objeto)
    {
    // Type of T is
    Type t = typeof(T);
    // Obtain Name
    string name = t.Name
    // Create another instance of T
    object to = Activator.CreateInstance<T>();
    // etc.
    }
