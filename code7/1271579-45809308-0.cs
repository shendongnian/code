            using (var w = new WebClient())
            {
                var json_data = string.Empty;
                string url = "YOUR URL";
                // attempt to download JSON data as a string
                try
                {
                    json_data = w.DownloadString(url);
                    JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
                    var result = jsSerializer.DeserializeObject(json_data);
                    Dictionary<string, object> obj2 = new Dictionary<string, object>();
                    obj2=(Dictionary<string,object>)(result);
                    string val=obj2["KEYNAME"].ToString();
                }
                catch (Exception) { }
                // if string with JSON data is not empty, deserialize it to class and return its instance 
            }
