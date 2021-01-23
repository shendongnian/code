    public class JsonHelper
    {
        public static T fromJson<T> (string json)
        {
            var bytes = Encoding.Unicode.GetBytes (json);
            using (MemoryStream mst = new MemoryStream(bytes))
            {
                var serializer = new DataContractJsonSerializer (typeof (T));
                return (T)serializer.ReadObject (mst);
            }
        }
        public static string toJson (object instance)
        {
            using (MemoryStream mst = new MemoryStream())
            {
                var serializer = new DataContractJsonSerializer (instance.GetType());
                serializer.WriteObject (mst, instance);
                mst.Position = 0;
                using (StreamReader r = new StreamReader(mst))
                {
                    return r.ReadToEnd();
                }
            }
        }
    }
