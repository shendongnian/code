    private bool IfContains(string needle, params string[] haystack)
    {
        bool match = false;
    
        foreach(string val in haystack)
        {
            if(val == needle)
            {
                match = true;
                break;
            }
        }
        return match;
    }
