	XmlDocument doc = new XmlDocument();
    doc.LoadXml("Your XML");
    foreach (XmlNode person in doc.SelectNodes("//person"))
	{
		int id = int.Parse(person.Attributes["id"].Value);
		List<int> votes = new List<int>();
		foreach (XmlNode node in person.SelectNodes("./votes"))
		{
			votes.Add(int.Parse(node.InnerText));
		}
		int voteCount = votes.Count;
		int voteSum = votes.Sum();
		Debug.WriteLine("Person {0}: {1} votes (sum {2})", id, voteCount, voteSum);
	}
