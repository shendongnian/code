    public class JSONSerializer
    {
        public void RunIt()
        {
            string json = "{\"A\":[\"a\",\"b\",\"c\",\"d\"],\"B\":[\"a\"],\"C\":[]}";
            JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            Rootobject jsonObject = serializer.Deserialize<Rootobject>(json);
            Console.Write(serializer.Serialize(jsonObject));
        }
    }
    public class Rootobject
    {
        public string[] A { get; set; }
        public string[] B { get; set; }
        public object[] C { get; set; }
    }
