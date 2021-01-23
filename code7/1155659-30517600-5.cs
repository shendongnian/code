	static void Main(string[] args) {
        //Generate a name for a temporary file
		var tempFile = Path.GetTempFileName();
        //Write the output of secedit.exe to the temporary file
		GenerateSecEditOutput(tempFile);
        //Parse the temporary file
		var iniFile = new IniFile(tempFile);
        //Read the maximum password age from the "System Access" section
		var maxPasswordAge = iniFile.GetInt("System Access", "MaximumPasswordAge");
		if (maxPasswordAge.HasValue) {
			Console.WriteLine("MaxPasswordAge = {0}", maxPasswordAge);
		} else {
			Console.WriteLine("Unable to find MaximumPasswordAge");
		}
		Console.ReadKey(true);
	}
