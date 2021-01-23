    public class MyClass
    {
      public static int Field1;
      public static int Field2;
      
      public static byte[] SerializeStatics()
      {
        using (var ms = new MemoryStream())
        {
          using (var bw = new BinaryWriter(ms))
          {
            bw.Write(Field1);
            bw.Write(Field2);
          }
          
          return ms.ToArray();
        }
      }
    }
