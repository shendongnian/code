    public static string Extract(string str, string keyword)
    {
        string[] arr = str.Split('.');
        string answer = string.Empty;
    
        foreach(string sentence in arr)
        {
            string[] words = sentence.Split(new char[] { ' ' });
            if(words.Contains(keyword)
            {
                answer += sentence;
            }
        }
    
        return answer;
    }
