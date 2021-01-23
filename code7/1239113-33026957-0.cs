	public static bool isHomogenous<T>(T[] list)
    {
        bool result = true;
        for (int i = 0; i < list.Length; i++)
            if (!list[i].Equals(list[0]))
                result = false;
        return result;
    }
