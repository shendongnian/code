    public static class StreamUtilities
    {
        public static T GetObject<T>(Byte[] rawimage) where T : class
        {
            try
            {
                MemoryStream memStream = new MemoryStream();
                
                BinaryFormatter binForm = new BinaryFormatter();
                memStream.Write(rawimage, 0, rawimage.Length);
                memStream.Seek(0, SeekOrigin.Begin);
                return binForm.Deserialize(memStream) as T;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static  Byte[] Serialize<T>(this T obj) where T:class
        {
            if (obj == null)
                return null;
            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();
            bf.Serialize(ms, obj);
            return ms.ToArray();
        }
    }
