    public static IMySerializableExtensions
    {
      public static byte[] MySerialize<T>(this T instance)
        where T : IMySerializable
      {
        byte[] result = // ...
        // code
        return result;
      }
      public static void MyDeserialize<T>(this T instance, byte[] value)
        where T : IMySerializable
      {
         // deserialize value and update values
      }
    }
