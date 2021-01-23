	public string[] LookUpPeerIpMany(string deviceName)
	{
		return _ipAddressesDictionary
               .Where(q=>q.Key.Contains(deviceName)).Select(q=>q.Value).ToArray();
	}
