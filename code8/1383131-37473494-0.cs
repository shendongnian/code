    // your data class
    public class YourClassName
    {
        ...
    }
    // Javascript serialization
    using System.IO;
    using System.Web.Script.Serialization;
    
    String json = new JavaScriptSerializer().Serialize(YourClassName);
    File.WriteAllText("json_file_path", json);
