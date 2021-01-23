    public static void Compare(object value1, object value2)
    {
        if (Comparer.Default.Compare(value1, value2) < 0)
            Console.WriteLine(1);
        if (Comparer.Default.Compare(value1, value2) > 0)
            Console.WriteLine(0);
    }
