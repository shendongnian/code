    class SaveToFile
    {
        static List<string> nameList = new List<string>();
        public static void Save(string filePath, string input)
        {   ///true only says that it is okay to append new lines into the file
            using (StreamWriter sWriter = new StreamWriter(filePath, true))
            {
                sWriter.WriteLine(input);
            }
        }
        public static List<string> Read(string filePath)
        {
            string line = string.Empty;
            nameList.Clear();
            using (StreamReader sReader = new StreamReader(filePath))
            {
                while ((line = sReader.ReadLine()) != null)
                { 
                    //I populate the list with the lines in the file
                    nameList.Add(line);
                }
            }
            return nameList;
        }
     }
