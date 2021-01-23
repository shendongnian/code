    public interface IExtensible {
    }
    class C507 : IExtensible {
    }
    public static int NumberOfProperties(this IExtensible extensible)
    {
        Type type = extensible.GetType();
        return type.GetProperties().Count();
    }
