    public class MySettings {
        public string RemoteServerAddress { get; set; }
        public int TcpCommunicationTimeout { get; set; }
    }
    public class Program {
        public readonly static MySettings ProgramSettings { get; private set; }
    
        static void Main(string[] args) {
            var serializer = new System.Xml.Serialization.XmlSerializer(typeof(MySettings));
            using(var stream = System.IO.File.OpenRead("config file path")){
                Program.ProgramSettings = (MySettings)serializer.Deserialize(stream);
            }
            SomeMethod();
        }
        static void SomeMethod(){
            if (Program.ProgramSettings.TcpCommunicationTimeout > 5) {
                ...
            }
        }
    }
