	public static void lineSplitCreator()
	{
		string[] linesOfPatientData = System.IO.File.ReadAllLines(@"C:\Users\Administrator.Rahul-HP\Desktop\test\dataOfPatient.txt");
		List<string[]> portionsOfAllData = new List<string[]>();
		
		// Read all lines and put them into this array
		foreach (string s in linesOfPatientData)
		{
			portionsOfAllData.Add(s.Split(';'));
		}
	}
