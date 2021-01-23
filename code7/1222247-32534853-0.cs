	var doc = XDocument.Parse(@"<?xml version=""1.0"" encoding=""utf - 8""?>
    <Report>
      <Version Name = ""2.0"">
        <Note>The meaning of life is 42.</Note>
        <Note>Hitchiker's Guide to the Galaxy</Note>
      </Version>
      <Version Name = ""2.1"">
        <Note>Football is awesome!</Note>
        <Note>Let's go sailing!</Note>
      </Version>
    </Report>");
	var lookup =
		doc
			.Descendants("Note")
			.ToLookup(
				x => x.Parent.Attribute("Name").Value,
				x => x.Value);
