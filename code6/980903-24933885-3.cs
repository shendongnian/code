            Dictionary<TKey, TValue> dict = new Dictionary<TKey, TValue>();
            XmlSerializer keySerializer = new XmlSerializer(typeof(TKey));
            XmlSerializer valueSerializer = new XmlSerializer(typeof(TValue));
            StringWriter textWriter = new StringWriter();
            string output ="<Dictionary>";
            foreach (TKey key in dict.Keys)
            {
                output += "<item>";
                output += "<key>";
                keySerializer.Serialize(textWriter, key);
                output += textWriter.ToString();
                output += "</key>";
                output += "<value>";
                TValue value = this[key];
                keySerializer.Serialize(textWriter, key);
                output += textWriter.ToString();
                output += "</value>";
                output += "</item>";
            }
            output += "</Dictionary>";
