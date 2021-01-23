    public void buildDirectoryFromFile(string file)
    {
        string line;
        StreamReader data = new StreamReader(file);           
        List<string> lines = new List<string>();
        while ((line = data.ReadLine()) != null)
        {
            lines.Add(line);
        
        }    
        int lineProcessed = 0;
        ParseTextIntoTree(lines, ref lineProcessed, 0);        
    }  
    public const int PadCount = 3; // Your padding length in text file
    public void ParseTextIntoTree(List<string> lineList, ref int lineProcessed, int depth)
    {
        while(lineProcessed < lineList.Count)
        {
            string line = lineList[lineProcessed++];
            int lineDepth = line.Length - line.TrimStart(' ').Length;
            if(lineDepth < depth)
            {
                // If the current depth is lower than the desired depth
                // end of directory structure is reached. Do backtrack
                // and reprocess the line in upper depth
                lineProcessed--;
                return;
            }
            if(line.EndsWith(":"))
            {
                // Do something, perhaps create directory?
                ParseTextIntoTree(lineList, ref lineProcessed, depth + PadCount);
            }
            else
            {
                // Do something, perhaps create file?
            }
        }
    }
