    public double GetObjectSize(Object Obj)
    {
         using (var m = new System.IO.MemoryStream())
         {
         System.Runtime.Serialization.Formatters.Binary.BinaryFormatter b = new
         System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
         b.Serialize(m, Obj);
         double size = Convert.ToDouble(m.Length);
         return size;
        }
    }
