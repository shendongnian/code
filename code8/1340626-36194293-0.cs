    Dictionary<Guid, UserSessionInfo> LoadUserSessionData()
    {
        try
        {
            var serializer = new XmlSerializer(typeof(KeyValuePair<Guid, UserSessionInfo>[]));
    
            using (var stream = new FileStream(@"UserSessionLookupDictionarySerialized.xml", FileMode.Open))
            {
                 var sessionData = (KeyValuePair<Guid, UserSessionInfo>[])serializer.Deserialize(stream)
                 return sessionData.ToDictionary(i => i.Key, i => i.Value);
            }
        }
        catch (FileNotFoundException)
        {
            return new Dictionary<int, UserSessionInfo>();
        }
    }
    void SaveUserSessionData(Dictionary<Guid, UserSessionInfo> sessionData)
    {
        var serializer = new XmlSerializer(typeof(KeyValuePair<Guid, UserSessionInfo>[]));
    
        using (var stream = new FileStream(@"UserSessionLookupDictionarySerialized.xml", FileMode. OpenOrCreate))
        {
             serializer.Serialize(stream, sessionData.ToArray());
        }
    }
