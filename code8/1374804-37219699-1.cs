    private byte[] ObjectToBytes(Object obj)
        {
           if(obj == null)
              return null;
           BinaryFormatter bf = new BinaryFormatter();
           using(MemoryStream ms = new MemoryStream()) {
               bf.Serialize(ms, obj);
               return ms.ToArray();
           }
        }
