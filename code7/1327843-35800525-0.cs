    void Main()
    {
	string[] allLines = {"Test", "Apple", "FishBowl", "Candy Cane", "Martini", "Husky"};
	
	
	
	for (int i = 0; i < allLines.Length - 1; i++)
    {
        for (int j = i + 1; j < allLines.Length; j++)
        {
           // allLines[i] = string.Copy(allLines[j]);
            if (allLines[i].CompareTo(allLines[j]) > 0)
            {
                string temp = allLines[i];
                allLines[i] = allLines[j];
                allLines[j] = temp;
            }
           
        }
        
        
    }
	Console.WriteLine(allLines);
    }
