      public static T Deserialize<T>(string xml){
            XmlSerializer xs = new XmlSerializer(typeof(T));
            string cleanXml = Regex.Replace(xml, @"<[a-zA-Z].[^(><.)]+/>",
                                            new MatchEvaluator(RemoveText));
            MemoryStream memoryStream = new MemoryStream((new UTF8Encoding()).GetBytes(cleanXml));
            XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);
            return (T)xs.Deserialize(memoryStream);
        }
    static string RemoveText(Match m) { return "";}
