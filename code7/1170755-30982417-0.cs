    JavaScriptSerializer serializer = new JavaScriptSerializer();
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void ProcessRequest(HttpContext context)
        {
            Console.WriteLine("check");
            ....
            return serializer.Serialize("{ isvalid: '" + response + "' }");
        }
