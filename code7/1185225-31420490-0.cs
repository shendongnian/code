	public static void lineSplitCreator()
	{
		string[] linesOfPatientData = System.IO.File.ReadAllLines(@"C:\Users\Administrator.Rahul-HP\Desktop\test\dataOfPatient.txt");
        // This is your jagged array.  We know how many rows will have from linesOfPatientData
		string[][] portionsOfAllData = new string[linesOfPatientData.Length][]; // The 2D array
		
		// Read all lines and put them into this array
		for (int i = 0; i < linesOfPatientData.Length; i++)
		{
			portionsOfAllData[i] = linesOfPatientData[i].Split(';');
		}
	}
