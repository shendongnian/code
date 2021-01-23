    public static object GetObjectFromPath(dynamic json, string path)
    {
         string[] segments = path.Split('.');
         foreach(string segment in segments)
            json = json[segment];
         return json;
    }
