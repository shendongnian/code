    public List<string> GetJsonItems()
    {
        int BracketCount = 0;
        string ExampleJSON = "{ bleh { bleh } bleh } {bleh2 }"; // Some JSON
        List<string> JsonItems = new List<string>();
        string Json = string.Empty;
    
        foreach (char c in ExampleJSON)
        {
            if (c == '{')
                ++BracketCount;
            else if (c == '}')
                --BracketCount;
            Json += c;
    
            if (BracketCount == 0 && c != ' ')
            {
                MessageBox.Show(Json);
                JsonItems.Add(Json);
                Json = string.Empty;
    
            }
        }
    
        return JsonItems;
    }
