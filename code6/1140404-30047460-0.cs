	if (!outerDictionary.ContainsKey(senderID))
	{
		outerDictionary[senderID] = new Dictionary<int, string>();
	}
	outerDictionary[senderID][numMessages] = txtSendMessage.Text;
