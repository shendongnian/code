    con.Open();
                var result = cmd.ExecuteScalar().ToString();
               
                con.Close();
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(result);
                XmlTextWriter writer = new XmlTextWriter(@"E:\Test\test.txt", null);
                writer.Formatting = Formatting.Indented;
                doc.Save(writer);
