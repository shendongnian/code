    List<string> dataToWrite = new List<string>(){
        "firstLine", "secondLine", "thirdLine"};
    using (StreamWriter writer = new StreamWriter("Assets/testWrite.txt"))
    {
        foreach (var line in dataToWrite)
        {
            writer.WriteLine(line);
            //writer.Write(line + Environment.NewLine);
            //writer.Write(line + "\r\n");
        }
    }
