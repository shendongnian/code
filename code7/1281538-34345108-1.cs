    public string[,] GetArrayFromFile(string fileName)
    {
        string[] fileData = File.ReadAllLines(fileName);
        string[,] result = new string[fileData.Length, 2];
        for (int i = 0; i < fileData.Length;i++)
        {
            string[] parts = fileData[i].Split(',');
            result[i, 0] = parts[0];
            result[i, 1] = parts[1];  //Probably want to .Trim() here
        }
        return result;
    }
