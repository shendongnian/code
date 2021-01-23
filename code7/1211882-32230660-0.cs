    public static Type GetById(int id)
    {
        switch (id)
        {
            case 1: return typeof(ClassA);
            case 2: return typeof(ClassA);
            case 3: return typeof(ClassA);
            // ... and so on
        }
    }
