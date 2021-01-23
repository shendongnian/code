            DataSet ds = new DataSet();
            using (XmlReader reader = XmlReader.Create(filePath))
            {
                reader.MoveToContent();
                while (reader.Read())
                {
                    if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "job"))
                    {
                        ds.ReadXml(reader);
                        DataTable dt = ds.Tables["job"];
                        if (dt.Rows.Count >= 1000)
                        {
                            // TODO: write batch to database
                            dt.Rows.Clear();
                        }
                    }
                }
                if (ds.Tables["job"].Rows.Count > 0)
                {
                    // TODO: write remainder to database
                    ds.Tables["job"].Rows.Clear();
                }
            }
