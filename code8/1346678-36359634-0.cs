    string[] allText = System.IO.File.ReadAllLines(theCSV);
    for (i = 1; i < allText.GetLength(0); i++)
    {
        string[] lineText = allText[i].Split(",");
        bool[] trueOrFalse = new bool[lineText.GetLength(0) - 3];
        for (i2 = 3; i2 < lineText.GetLength(0); i2++)
        {
            trueOrFalse[i2] = lineText[i2] == allText[0].Split(",")[i2] ? true : false;
        }
    }
