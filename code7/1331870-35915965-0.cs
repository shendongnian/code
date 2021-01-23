    public BackgroundJobInfo Deserialize(string info)
    {        
            try
            {
              using (var stringReader = new StringReader(info))
              {
                var xmlTextReader = XmlReader.Create(stringReader);
                return (BackgroundJobInfo)Serializer.ReadObject(xmlTextReader);
              }
            }
            catch (Exception e)
            {
                _logger.ErrorException(e, "Error when deserializing a BackgroundJobInfo object from string <{0}>", info);
                 return null;
            }    
    }
