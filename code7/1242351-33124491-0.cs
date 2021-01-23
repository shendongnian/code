    public static T Deserialize<T>(byte[] data) where T : IRequest
    { 
        return Deserialize(typeof(T), byte[] data) as T;
    }
    public static object Deserialize(Type, byte[] data)
    { 
       ...
    }
