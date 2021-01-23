    public static dynamic DecodeJson(this string str)
    {
        var serializer = new JavaScriptSerializer();
        serializer.MaxJsonLength = Int.MaxValue; // The value of this constant is 2,147,483,647
        serializer.RegisterConverters(new[] { new DynamicJsonConverter() });
        dynamic result = null;
        try
        {
            result = serializer.Deserialize(str, typeof(object));
        } catch (ArgumentException ae)
        {
            Log.Output(ae.InnerException.Message);
        }
        return result;
    }
