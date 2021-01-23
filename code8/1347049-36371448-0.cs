	var allExtensions = new List<string>();
	RegistryKey root = Registry.ClassesRoot;
	string[] subKeys = root.GetSubKeyNames();
	foreach (string subKey in subKeys) // now it's better to use Linq
	{
		if (subKey.StartsWith("."))
		{
			allExtensions.Add(subKey);
		}
	}
