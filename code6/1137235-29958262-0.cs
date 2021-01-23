    public class XmlCodec<T>
    {
        public List<string> MyList = new List<string>();
        public string GetCollectionName()
        {
            return "Some Collection Name";
        }
        public void ReadCollection(string collectionName)
        {
            for (int i = 0; i < 100; i++)
                MyList.Add(collectionName + i.ToString());
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Type xmlCodecType = typeof(XmlCodec<>).MakeGenericType(typeof(string));
            dynamic xmlCodec = Activator.CreateInstance(xmlCodecType);
            xmlCodec.ReadCollection(xmlCodec.GetCollectionName());
            Print(xmlCodec);
            Console.ReadKey(true);
        }
        public static void Print(dynamic obj)
        {
            foreach (string s in obj.MyList)
                Console.WriteLine(s);
        }
    
    }
