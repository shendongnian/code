    public IEnumerable<string> LookUpPeerIp(string deviceName)
    {
        var keySubstringMatch = _ipAddressesDictionary.Keys
            .Where(key => key.Contains(deviceName));
        foreach (string key in keySubstringMatch)
            yield return _ipAddressesDictionary[key];
        yield break;
    } 
