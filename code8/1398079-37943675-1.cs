    using(TextReader textReader = new StreamReader(responseStream))
            {
                XmlTextReader reader = new XmlTextReader(textReader);
                while(reader.Read())
                {
                    if(reader.Name.Equals("line_1"))
                    {
                        option1 = reader.ReadString();
                    }
                    if(reader.Name.Equals("udprn"))
                    {
                        option2 = reader.ReadString();
                    }
                    if(option1 != "" && option2 != "")
                    {
                        dtReturn.Rows.Add(new object[] { option1, option2 });
                        option1 = "";
                        option2 = "";
                    }
                }
            }
