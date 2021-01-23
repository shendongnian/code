    TransactionResponse result = new TransactionResponse();
    if(!string.IsNullOrEmpty(responseData))
    {
        XmlSerializer serializer = new XmlSerializer(typeof(TransactionResponse));
    
        using(TextReader xmlreader = new StringReader(responseData))
        {
            result = (TransactionResponse) serializer.Deserialize(xmlreader);
        }
    }
