    [WebMethod]
        public static string getJson()
        {
            List<String> surname = YourFunctionForSurNames();
            // instantiate a serializer
            JavaScriptSerializer TheSerializer = new JavaScriptSerializer();
            var TheJson = TheSerializer.Serialize(surname);            
            return TheJson;
        }
