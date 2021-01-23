	string UNCtoMappedDrive(string uncPath)
	{
		Microsoft.Win32.RegistryKey rootKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("network");
		foreach (string subKey in rootKey.GetSubKeyNames())
		{
			Microsoft.Win32.RegistryKey mappedDriveKey = rootKey.OpenSubKey(subKey);
			if (string.Compare((string)mappedDriveKey.GetValue("RemotePath", ""), uncPath, true) == 0)
				return subKey.ToUpperInvariant() + @":\";
		}
		return uncPath;
	}
