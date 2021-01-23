    class MyClass
    {
         public string email_address { get; set; }
         public string status { get; set; }
    }
    
    List<MyClass> data = new List<MyClass>() { new MyClass() { email_address = "email1@email.com", status = "good2go" }, new MyClass() { email_address = "email2@email.com", status = "good2go" } };
    
    //Serialize
    var json = JsonConvert.SerializeObject(data);
    
    //Deserialize
    var jsonToList = JsonConvert.DeserializeObject<List<MyClass>>(json);
