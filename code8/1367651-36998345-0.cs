    void CompareJSON()
    {
        string json = @"{""Type"":1, ""Id"":1000,""Date"":null,""Group"": ""Admin"",""Country"":""India"",""Type"":1}";
        string jsonToCompare = "JSON TO COMPARE";
        MyObject myJsonObject = JsonConvert.DeserializeObject<MyObject>(json);
        MyObject myJsonObjectToCompare = JsonConvert.DeserializeObject<MyObject>(jsonToCompare);
            
        if (myJsonObject.Id == myJsonObjectToCompare.Id)
        {
            // Do something
        }
    }
    class MyObject
    {
        public int Id { get; set; }
        public int Type { get; set; }
        public DateTime? Date { get; set; }
        public string Group { get; set; }
        public string Country { get; set; }
    }
