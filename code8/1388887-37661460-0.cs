    string allText = System.IO.File.ReadAllText(settingsFile);
    if (allText.Length == 0)
    {
    	// Set all checkBoxes to be unchecked
    }
    else
    {
    	string[] values = allTextSplit(',');
        // ......
    }
