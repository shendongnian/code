    public static string TypePrinter<T>()
    {
        return String.Format("blahblah: {0}", typeof(T).FullName));
    }
    TypePrinter<System.String>();
