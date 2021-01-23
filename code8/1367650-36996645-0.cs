        private void Test() {
            string json = @"{""Type"":1, ""Id"":1000,""Date"":null,""Group"": ""Admin"",""Country"":""India"",""Type"":1}";
            JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
            MyJsonObject myJsonObject = jsonSerializer.Deserialize<MyJsonObject>(json);
            string s = jsonSerializer.Serialize(myJsonObject);
            //Returns: {"Id":1000,"Type":1,"Date":null,"Group":"Admin","Country":"India"}
        }
    class MyJsonObject {
        public int Id { get; set; }
        public int Type { get; set; }
        public DateTime? Date { get; set; }
        public string Group { get; set; }
        public string Country { get; set; }
    }
