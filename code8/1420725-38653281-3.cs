    public static void LoadDatabase(string databasePath)
    {
        string[] fileContents;
        // End process if database doesn't exist
        if (File.Exists(databasePath))
            return;
        fileContents = File.ReadAllLines(databasePath); // Read all lines seperately and put them into an array
        foreach (string str in fileContents)
        {
            string fileName = str.Split(':')[0]; // Get the filename
            string tags = str.Split(':')[1]; // Get the tags
            // Do what you must with the information
        }
    }
