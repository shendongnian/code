    using (TextReader xmlreader = new StringReader(responseData))
     {
       QueryResponse value = (QueryResponse)serializer.Deserialize(xmlreader);
       result = value.transaction;
       
      DateTime autDate = DateTime.MinValue;
    
      if (!string.IsNullOrEmpty(result.AuthDateXML))
       {
        DateTime.TryParseExact(result.AuthDateXML, "dd-MM-yyyy HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out autDate);
         result.AuthDate = autDate;
       }
    }
