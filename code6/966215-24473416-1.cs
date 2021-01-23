    [JsonConverter(typeof(IPAddressConverter))]
    public class IPAddress
    {
        byte[] bytes;
        public IPAddress(string address)
        {
            bytes = address.Split('.').Select(s => byte.Parse(s)).ToArray();
        }
        public override string ToString() 
        { 
            return string.Join(".", bytes.Select(b => b.ToString()).ToArray()); 
        }
    }
