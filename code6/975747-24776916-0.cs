    Dictionary<string, List<string>> data = new Dictionary<string,List<string>>();
    using (StreamReader reader = File.OpenText(filename))
    {
        while (!reader.EndOfStream)
        {
            string dirName = reader.ReadLine();
            List<string> currentFiles = new List<string>();
            data.Add(dirName, currentFiles);
            string fileName;
            while (!reader.EndOfStream && (fileName = reader.ReadLine()).Trim() != "")
            {
                currentFiles.Add(fileName);
            }
        }
    }
