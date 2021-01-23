    using System.Xml;
    using System.Xml.Serialization;
    using System.IO;
    class Program
    {
        static void Main(string[] args)
        {
            var xml = @"<MyClass><A>a</A><b>b</b></MyClass>";
            var ms = new MemoryStream(Encoding.UTF8.GetBytes(xml));
            
            var ser = new XmlSerializer(typeof(MyClass));
            var instance = (MyClass)ser.Deserialize(ms);
            Console.WriteLine(instance.A);
            Console.WriteLine(instance.b);
            var final = Console.ReadLine();
        }
    }
    
    [Serializable]
    public class MyClass
    {
        public MyClass()
        {
            this.A = "a";
            this.b = "b";
        }
        public string A { get; set; }
        public string b { get; set; }
    }
