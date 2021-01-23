    public class IPAddress
    {
        byte[] bytes;
    
        public override string ToString() {... etc.
    }
    
    IPAddress ip = new IPAddress("192.168.1.2");
    var obj = new () {ipValue = ip.ToString()};
    string json = JsonConverter.SerializeObject(obj);
