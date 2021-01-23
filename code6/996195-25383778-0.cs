    byte[] ToByteArray(Object obj)
    {
        if(obj != null)       
        {
            using(var ms = new MemoryStream())
            {
               var bf = new BinaryFormatter()
               bf.Serialize(ms, obj);
               return ms.ToArray();
            }
        }
    
        return null;
    }
