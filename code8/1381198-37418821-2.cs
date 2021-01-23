    public void SaveFileXML(string filePath, List<Context> itemList)
    {
                using (var stream = new FileStream(filePath, FileMode.OpenOrCreate))
                {
                    try
                    {
                        var format = new XmlSerializer(typeof(List<Context>));                    
                        format.Serialize(stream, itemList);
                    }
                    catch (InvalidOperationException exc)
                    {
                        //Handle error
                    }    
                }    
    }
