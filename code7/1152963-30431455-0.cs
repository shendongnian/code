    [Serializable]
    public class Model
        {
            public string element = "elTest";
            [XmlArrayItem("role")]
            public List<String> roles;
        }
        class Program
        {
            static void Main(string[] args)
            {
                var me = new Model();
                me.roles = new List<string>()
            {
                "testString"
            };
                var ser = new XmlSerializer(me.GetType());
                using (var sw = new StreamWriter("0.xml"))
                {
                    ser.Serialize(sw, me);
                }
                
                Console.ReadKey(true);
            }
    }
