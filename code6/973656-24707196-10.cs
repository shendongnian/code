        // I represent the wrapper result
        class Result
        {
            public List<string> html_attributions { get; set; }
            public string next_page_token { get; set; }
            public List<ResultItem> results { get; set; }
        }
        // I represent a result item
        class ResultItem
        {
            public string id { get; set; }
            public string name { get; set; }
        }
        // the actual deserialization
        Result Deserialize(string json)
        {
            var serializer = new JavaScriptSerializer();
            return serializer.Deserialize(json, typeof(Result));
        }
