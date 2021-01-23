    string filePath = ""; // from OpenFileDialog
    
    string fileContents = File.ReadAllText(filePath);
    string[] values = fileContents.Split();
    int valueInt, greaterValuesCount = 0;    
    foreach (var value in values)
    {
        if (int.TryParse(value, out valueInt))
        { 
            greaterValueCount++;
            // Do something else here
        }
    }
