        [DataContract]
        public class Data
        {
            [DataMember]
            public List<Items> photos { get; set; }
        }
        [DataContract]
        public class Items
        {
            [DataMember(Name = "3")]
            public string Three { get; set; }
            [DataMember(Name="0")]
            public string Zero { get; set; }
            [DataMember(Name = "2")]
            public string Two { get; set; }
        }
        public static void TestJson()
        {
            var json = "{\"photos\":[{\"0\":\"some data\",\"2\":\"other data\",\"3\":\"another data\"}]}";
            var serializer = new DataContractJsonSerializer(typeof(Data));
            Data data = serializer.ReadObject(new MemoryStream(Encoding.UTF8.GetBytes(json))) as Data;
        }
