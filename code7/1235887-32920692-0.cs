    public IEnumerable<KeyValuePair<string, string>> GetPhoneBookData()
    {
        var phoneBookXml = ParseXml.Deserialize<PhoneBookXml>(_path);
        foreach (var item in phoneBookXml.Properties)
        {
            _phoneBookDict.Add(new KeyValuePair<string, string>(item.Key, item.Value));
        }
        return _phoneBookDict;
    }
