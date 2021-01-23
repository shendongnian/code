    public static void AddElement<T>(List<Base> list, int number) where T : Base, new()
    {
        for (int i = 0; i < number; i++)
        {
            list.Add(new T());
        }
    }
