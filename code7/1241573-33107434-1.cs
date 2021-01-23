    public static IMySerializableExtensions
    {
      public static byte[] MySerialize(this IMySerializable instance)
      {
        byte[] result = // ...
        // code
        return result;
      }
      public static void MyDeserialize(this IMySerializable instance, byte[] value)
      {
         // deserialize value and update values
      }
    }
