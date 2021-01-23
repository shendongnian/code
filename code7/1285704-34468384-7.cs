    private string GetStringByName(string name)
    {
		var id = Resources.GetIdentifier(name, "string", PackageName);
		return id == 0 ? string.Empty : Resources.GetText(id);
	}
