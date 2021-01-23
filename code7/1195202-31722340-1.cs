        public static string[] replacer(Dictionary<string,string> dic, string data) 
        {
            foreach (KeyValuePair<string,string> entry in dic)
            {
                data = data.Replace(entry.Key, entry.Value);
            }
            string[] lines =  data.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            return lines;
        }
