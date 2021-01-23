    class ExampleModel {
     public string property1 {get;set;}
     public IList<string> property2 {get;set;}
    }
    var complexObject = new ExampleModel();
    //Set your values here then post it
    client.PostAsJsonAsync("api/Utility/SendMailMessageFromandToList",complexObject);
