    int common = 10;
    Dictionary<List<int>, string> index = new Dictionary<List<int>, string>();
    List<int> linesOfContent = new List<int>();
    for(int i = 0; i < 5; i++)
    {
        for(int j = 0; j < 5; j++)
        {       
            linesOfContent.Add(i);
        }
        index.Add(linesOfContent, ":"+common.ToString());
    }
