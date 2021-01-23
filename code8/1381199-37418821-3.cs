    public List<Context> ReadXml(string filePath)
    {
                List<Context> result = null;
                using (var stream = new FileStream(filePath, FileMode.OpenOrCreate))
                {    
                    try
                    {
                        var format = new XmlSerializer(typeof(List<Context>));
                       // deserialize returns an object so it must be cast.
                        result = format.Deserialize(stream) as List<Context>;
                       
                    }
                    catch (InvalidOperationException exc)
                    {
                        //Handle error
                    }
                }
                return result;
    }
