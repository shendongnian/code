    public static void WriteDataListToFile<T>(IEnumerable<T> dataList, string folderPath, string fileName) //no type constraints
    {
        //your other things
        foreach(T type in dataList)
        {
            sw.WriteLine(type.ToString());
        }
    }
