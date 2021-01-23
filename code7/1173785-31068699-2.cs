    public List<string> GetJsonItems()
    {
        int BracketCount = 0;
        string ExampleJSON = new StreamReader(@"c:\Json.txt").ReadToEnd();
        List<string> JsonItems = new List<string>();
        StringBuilder Json = new StringBuilder();
    
        foreach (char c in ExampleJSON)
        {
            if (c == '{')
                ++BracketCount;
            else if (c == '}')
                --BracketCount;
            Json.Append(c);
    
            if (BracketCount == 0 && c != ' ')
            {
                JsonItems.Add(Json.ToString());
                Json = new StringBuilder();
    
            }
        }
        return JsonItems;    
    }
