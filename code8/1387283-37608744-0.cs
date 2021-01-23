        [System.Web.Services.WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<int> GetDataBehzad()
        {
            List<int> list = new List<int>();
            list.Add(10);
            list.Add(100);
            return list;
        }
