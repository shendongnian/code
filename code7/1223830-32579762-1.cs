	static void PatchFile(string filename, string searchString, string replaceString)
	{
		// Open the file
		using (var file = File.Open(filename, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite))
		{
			// Locate the search string in the file (needs to be implemented)
			long pos = FindString(file, searchString);
			if (pos < 0)
				return;
			// Pad and limit replacement string, then convert to bytes
			string rep = string.Format("{0,-" + searchString.Length + "}", replaceString).Substring(0, searchString.Length);
			byte[] replaceBytes = Encoding.Unicode.GetBytes(rep);
			// Overwrite the located bytes with the replacement
			file.Position = pos;
			file.Write(replaceBytes, 0, replaceBytes.Length);
		}
	}
