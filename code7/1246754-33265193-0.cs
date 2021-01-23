    public Message ChangeString(Message oldMessage, string from, string to)
    {
        MemoryStream ms = new MemoryStream();
        XmlWriter xw = XmlWriter.Create(ms);
        oldMessage.WriteMessage(xw);
        xw.Flush();
        string body = Encoding.UTF8.GetString(ms.ToArray());
        xw.Close();
        body = body.Replace(from, to);
        ms = new MemoryStream(Encoding.UTF8.GetBytes(body));
        XmlDictionaryReader xdr = XmlDictionaryReader.CreateTextReader(ms, new XmlDictionaryReaderQuotas());
        Message newMessage = Message.CreateMessage(xdr, int.MaxValue, oldMessage.Version);
        newMessage.Properties.CopyProperties(oldMessage.Properties);
        return newMessage; 
    }
