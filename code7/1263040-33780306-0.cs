    private FileClass GetFile(int row)
    {
        using(StreamReader streamReader = new StreamReader(fileStream)) 
        {
        streamReader.BaseStream.Seek(row*19, SeekOrigin.Begin);
        string line = streamReader.ReadLine();
        string[] linepart = line.Split('\t');
        return new FileClass()
                {
                    Field1 = linepart[0],
                    Field2 = linepart[1],
                    Field3 = linepart[2]
                };
        }
    }
