    public static T CreateInstance<T>(Rectangle rect) where T : Control, new()
    {
        T c = new T()
        c.Location = rect.Location;
        c.Size = rect.Size;
        return c;
    }
