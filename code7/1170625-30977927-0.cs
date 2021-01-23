    namespace ConsoleApplication8
    {
    public class Person
    {
        public int PersonID { get; set; }
        //public string Name { get; set; }
        public bool Registered { get; set; }
        public string s1 { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var s = "{\"PersonID\":1,\"Name\":\"Name1\",\"Registered\":true}";
            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            var o = serializer.Deserialize<Person>(s);
            ;
        }
    }
    }
