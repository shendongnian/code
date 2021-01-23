    public string GetPdbFile(string assemblyPath) 
    {
		string s = File.ReadAllText(assemblyPath);
		int pdbIndex = s.IndexOf(".pdb", StringComparison.InvariantCultureIgnoreCase);
		if (pdbIndex == -1)
            throw new Exception("PDB information was not found.");
		
		int lastTerminatorIndex = s.Substring(0, pdbIndex).LastIndexOf('\0');
		return s.Substring(lastTerminatorIndex + 1, pdbIndex - lastTerminatorIndex + 3);
    }
    public string GetPdbFile(Assembly assembly) 
    {
        return GetPdbFile(assembly.Location);
    }
