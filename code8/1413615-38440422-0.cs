     private static byte[] GetBuffer<T>(T obj) {
         using (var m = new MemoryStream()) {
             var ser = new DataContractSerializer(obj.GetType());
             ser.WriteObject(m, obj);
             return m.ToArray();
         }   
     }
