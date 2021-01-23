        public static string createConnectionString(Dictionary<string,string> parameters)
        {
            string res = string.Empty;
            foreach (KeyValuePair<string,string> entry in parameters)
            {
                res += entry.Key + "=" + entry.Value + ";";
            }
            return res;
        }
