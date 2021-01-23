    private string DataSetToXml(DataSet ds)
            {
                using (var ms= new MemoryStream())
                {
                    using (TextWriter sw= new StreamWriter(ms))
                    {
                        var xmlSerializer = new XmlSerializer(typeof(DataSet));
                        xmlSerializer.Serialize(sw, ds);
                        return Encoding.UTF8.GetString(memoryStream.ToArray());
                    }
                }
            }
