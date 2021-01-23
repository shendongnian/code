    [DataContract]
    public class BaseResponse
    {
        [DataMember]
        public bool Success { get; set; }
        [DataMember]
        public List<string> Messages { get; set; }
        public BaseResponse()
        {
            Messages = new List<string>();
        }
        public static T fromJson<T>(string json)
        {
            System.Runtime.Serialization.Json.DataContractJsonSerializer js = new System.Runtime.Serialization.Json.DataContractJsonSerializer(typeof(T));
            MemoryStream ms = new MemoryStream(System.Text.UTF8Encoding.UTF8.GetBytes(json));
            T obj = (T)js.ReadObject(ms);
            return obj;
        }
        public string toJson()
        {
            System.Runtime.Serialization.Json.DataContractJsonSerializer js = new System.Runtime.Serialization.Json.DataContractJsonSerializer(this.GetType());
            MemoryStream ms = new MemoryStream();
            js.WriteObject(ms, this);
            ms.Position = 0;
            StreamReader sr = new StreamReader(ms);
            return sr.ReadToEnd();
        }
        public virtual void print()
        {
            Console.WriteLine("Class: " + this.GetType());
            Console.WriteLine("[Success] " + this.Success);
            foreach (string str in this.Messages)
                Console.WriteLine("[Messages] " + str);
        }
    }
