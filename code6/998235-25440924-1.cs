    public static T CreateInstance<T>(int x, int y, int w, int h) where T : Control, new()
    {
        T c = new T()
        c.Location = new Point(x, y);
        c.Size = new Size(w, h);
        return c;
    }
