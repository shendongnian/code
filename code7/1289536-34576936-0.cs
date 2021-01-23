                while (reader.Read())
                {
                    if (reader.Name.Equals("Group"))
                    {
                        XElement group =  (XElement)XDocument.ReadFrom(reader);
                    }
                }
                reader.Close();​
