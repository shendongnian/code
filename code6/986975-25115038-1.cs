    private static string GetDirectory(string folderPath, string number)
    {
        foreach (string directory in Directory.GetDirectories(folderPath))
        {
            if (directory.Contains(number))
            {
                return directory;
            }
            string result = GetDirectory(directory, number);
            if (!string.IsNullOrEmpty(result))
            {
                return result;
            }
        }
        return null;
    }
