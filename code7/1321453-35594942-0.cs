    public static class JsonFormatter
    {        
        public static string KendoJsonResult(this IEnumerable enumerable, DataSourceRequest request)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = Int32.MaxValue; //Here change the default max size to Maximum possible value, that is Int32.MaxValue
            var jsonData = serializer.Serialize(enumerable.ToDataSourceResult(request));          
            return jsonData;           
        }
    }
