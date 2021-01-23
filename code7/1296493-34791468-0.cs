    public static string SubData(Selection item)
    {
        var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
        //ERROR OCCURS HERE
        var selection = serializer.Deserialize(item.ToString());
        return "this is successful";
    }
