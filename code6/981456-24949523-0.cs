    public static void SetWheels<T>(T item, int wheels) where T : Vehicle
    {
        if (item != null)
        {
            item.Wheels = wheels;
        }
    }
