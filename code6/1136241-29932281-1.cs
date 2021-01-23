    public enum WebClientMessageType
    {
        KeepAliveMessage,
    }
    [KnownType(typeof(KeepAliveMessage))]
    [DataContract(Name="WebClientMessage", Namespace="http://schemas.datacontract.org/2004/07/Data.WebGateway")]
    public abstract class WebClientMessage
    {
        public WebClientMessage() { }
        [DataMember]
        public int MessageId { get; set; }
        [DataMember]
        public WebClientMessageType Type { get; set; }
    }
    [DataContract(Name = "KeepAliveMessage", Namespace = "http://schemas.datacontract.org/2004/07/Data.WebGateway")]
    public class KeepAliveMessage : WebClientMessage
    {
        public KeepAliveMessage() { }
        [DataMember]
        public int PositionInQueue { get; set; }
    }
    public static class DataContractJsonSerializerHelper
    {
        public static string GetJson<T>(T obj, DataContractJsonSerializer serializer)
        {
            using (var memory = new MemoryStream())
            {
                serializer.WriteObject(memory, obj);
                memory.Seek(0, SeekOrigin.Begin);
                using (var reader = new StreamReader(memory))
                {
                    return reader.ReadToEnd();
                }
            }
        }
        public static string GetJson<T>(T obj)
        {
            var serializer = new DataContractJsonSerializer(typeof(T));
            return GetJson(obj, serializer);
        }
        public static T GetObject<T>(string json, DataContractJsonSerializer serializer)
        {
            using (var stream = GenerateStreamFromString(json))
            {
                var obj = serializer.ReadObject(stream);
                return (T)obj;
            }
        }
        public static T GetObject<T>(string json)
        {
            var serializer = new DataContractJsonSerializer(typeof(T));
            return GetObject<T>(json, serializer);
        }
        private static MemoryStream GenerateStreamFromString(string value)
        {
            return new MemoryStream(Encoding.Unicode.GetBytes(value ?? ""));
        }
    }
