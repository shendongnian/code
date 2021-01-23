    public class SerializationHelper
    {
       public bytes[] Encode(this Binary<T> instance)
       {
          ... serialization logic
       }
                 // or MyClass
       public static Binary<T> Decode(this Binary<T> instance, bytes[] byte) 
       {
          ... deserialization logic
       }
    }
    class MyClass<T> : Binary<T>
    {
       internal byte[] Encode() { ... } 
       internal static T Decode(byte[] bytes) { ... }
    }
