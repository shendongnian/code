    public class VirtualFloatArray
    {
       public byte[] ExtensionBytes {get;set;}
       public int Length { return ExtensionBytes.Length / sizeof(float); }
       public float this[int index]
       {
          get 
          {
             var result = new float[1]{};
             Buffer.BlockCopy(ExtensionBytes, index * sizeof(float), result, 0, sizeof(float));
             return result[0];
          }
       }
    }
