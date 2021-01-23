     System.IO.MemoryStream m = new System.IO.MemoryStream();
     System.Runtime.Serialization.Formatters.Binary.BinaryFormatter b = new
     System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
     b.Serialize(m, Obj);
     double size = Convert.ToDouble(m.Length);
