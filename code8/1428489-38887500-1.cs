    int common = 10;
    List<List<string>> index = new List<List<string>>();
    List<string> linesOfContent = new List<string>();
    for(int i = 0; i < 5; i++)
    {
        for(int j = 0; j < 5; j++)
        {       
            linesOfContent.Add(i.ToString() +":"+common.ToString());
        }
        index.Add(linesOfContent);
    }
