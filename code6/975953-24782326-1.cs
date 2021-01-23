        private string GetKeyValuePairs(string jsonString)
        {
            var resDict = JsonConvert.DeserializeObject<Dictionary<string, object>>(jsonString);
            string sdict = string.Empty;
            foreach (string key in resDict.Keys)
            {
                sdict += "<br/> " + key + " : " + (resDict[key].GetType() == typeof(JObject) ? GetKeyValuePairs(resDict[key].ToString()) : resDict[key].ToString());
            }
            return sdict;
        }
