           public DataPDU Deserialize(string filepath)
            {
                XmlSerializer deserializer = new XmlSerializer(typeof(DataPDU));
                UTF8Encoding utf8 = new UTF8Encoding(true);
                StreamReader reader = new StreamReader(filepath, utf8);
                string text = reader.ReadToEnd();
                string pattern = "(</?)(\\w+:)";
                string fixedText = Regex.Replace(text,pattern,"$1");
                StringReader fixedReader = new StringReader(fixedText);
                object obj = deserializer.Deserialize(fixedReader);  //error raising here
                DataPDU XmlData = (DataPDU)obj;
                reader.Close();
                return XmlData;
            }
