     public static string GetXMLFromJson(string jsonString)
            {
                 string parentNote="Person";
                XDocument doc = (XDocument)JsonConvert.DeserializeXNode("{\""+ parentNote + "\":" + json + "}", "DocumentElement");
                return doc.ToString();
            }
