    public static void WriteDataListToFile<T>(IEnumerable<T> dataList, string folderPath, string fileName)
    {
        //Check to see if file already exists
        if (!File.Exists(folderPath + fileName))
        {
            //if not, create it
            File.Create(folderPath + fileName);
        }
        using (StreamWriter sw = new StreamWriter(folderPath + fileName))
        {
            foreach (T type in dataList)
            {
                sw.WriteLine(type.ToString());
            }
        }
    }
