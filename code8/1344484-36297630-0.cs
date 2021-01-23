            List<XElement> jobs = new List<XElement>();
            using (XmlReader reader = XmlReader.Create(filePath))
            {
                XElement job;
                reader.MoveToContent();
                while (reader.Read())
                {
                    if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "job"))
                    {
                        job = XElement.ReadFrom(reader) as XElement;
                        jobs.Add(job);
                        if (jobs.Count >= 1000)
                        {
                            // TODO: write batch to database
                            jobs.Clear();
                        }
                    }
                }
                if (jobs.Count > 0)
                {
                    // TODO: write remainder to database
                    jobs.Clear();
                }
            }
