    using System.Web.Script.Serialization;
    ...
  
    string stringValue = JavaScriptSerializer().Serialize(YourJsonObject);
    //YourJsonObject here would be the object you are getting the value from.
