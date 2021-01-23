    private string Serialize(Customer cus)
    {
        try
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Customer));
            XmlTextWriter xmlTextWriter = new XmlTextWriter((Stream)new MemoryStream(), Encoding.UTF8);
            xmlSerializer.Serialize((XmlWriter)xmlTextWriter, (object)cus);
            return this.UTF8ByteArrayToString(((MemoryStream)xmlTextWriter.BaseStream).ToArray());
        }
        catch (Exception ex)
        {
            return string.Empty;
        }
    }
    private string UTF8ByteArrayToString(byte[] characters)
        { 
            return new UTF8Encoding().GetString(characters);
            //return characters.ToString(); 
        }
