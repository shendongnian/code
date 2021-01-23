    {
        "Id":"07",
        "Language": "C++"
    }
        
    public class CSharpObject
    {
        int Id {get; set;}
        string Language {get; set;}
    }
    
    
    string json = HttpUtility.HtmlDecode(jsonString);
    JavaScriptSerializer json_serializer = new JavaScriptSerializer();
    CSharpObject csharpObject = (CSharpObject)json_serializer.Deserialize<CSharpObject>(json);
