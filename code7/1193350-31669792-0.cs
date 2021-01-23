    public interface IBinary<T>
    {
        byte[] Encode(); // Alterantive definition as extension method below
    }
    public static class Binary
    {
        public static T Decode<T>(byte[] bytes) where T : IBinary<T>¨
        {
            // deserialization logic here
        }
        // If you want, you can define Encode() as an extension method instead:
        public static byte[] Encode<T, TBinary>(this TBinary binary)
            where TBinary : IBinary<T>
        {
            // serialization logic here
        }
    }
