    private static List<float> method4(int n)
    {
        var list = new List<float>(n);
        list.GetType().GetField("_size", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(list, n);
        return list;
    }
