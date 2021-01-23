    public string[] GetPdbFiles(string assemblyPath) 
    {
		string s;
		using (var stream = new FileStream(assemblyPath, FileMode.Open, FileAccess.Read))
		{
			using (var sr = new StreamReader(stream))
			{
				s = sr.ReadToEnd();
			}
		}
		List<string> pdbPaths = new List<string>();
		int pdbIndex = s.IndexOf(".pdb", StringComparison.InvariantCultureIgnoreCase);
		while (pdbIndex != -1)
		{
			int lastTerminatorIndex = s.Substring(0, pdbIndex).LastIndexOf('\0');
			pdbPaths.Add(s.Substring(lastTerminatorIndex + 1, pdbIndex - lastTerminatorIndex + 3));
			pdbIndex = s.IndexOf(".pdb", pdbIndex + 1, StringComparison.InvariantCultureIgnoreCase);
		}
        return pdbPaths.ToArray();
    }
    public string[] GetPdbFiles(Assembly assembly) 
    {
        return GetPdbFiles(assembly.Location);
    }
