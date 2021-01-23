    class Program
    {
        static void Main(string[] args)
        {
            string json = @"{ ""Foo"": null, ""Melda"": 123 }";
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.Converters.Add(new MyMessageConverter());
            MyMessage msg = JsonConvert.DeserializeObject<MyMessage>(json, settings);
        }
    }
    [DataContract]
    public class MyMessage
    {
        [DataMember(IsRequired = false)]
        public string Foo { get; set; }
        [DataMember(IsRequired = false)]
        public string Bar { get; set; }
        public void NotifyPropertyFound(string propName)
        {
            // Write to the console each time this method is called
            Console.WriteLine(propName);
        }
    }
