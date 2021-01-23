    public class ValidationResults 
    {
       bool Valid {get;set;}
       string Message {get;set;}
    }
    
    public JsonResult CreateWithJson(List<string> values) 
    {
      if (values == null) return Json(new ValidationResults { Valid = false, Message = "No data was received by the server" });
    }
    
    public static void TestEmptyDataFailsGracefully()
    {
      var objUt = new MyController();
      var actual = objUt.CreateWithJson(new List<string>());
      
      actual.Should().BeOfType(typeof(JsonResult));
      
      var serializer = new JavaScriptSerializer();
      var json = serializer.Serialize(actual.Data);
      ValidationResults validationResult = serializer.Deserialize<ValidationResults>(json);
    
    
      // what I want to do
      validationResult .Valid.Should.Be(false);
    }
