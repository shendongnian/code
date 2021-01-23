    public static void ParseMsg(string msg)
    {
        string[] words = Regex.Split(msg, @"\s+");
        foreach (string word in words)
        {
            switch (word)
            {
                case "tween":
                    // Do something
                    break;
                case "stop":
                    // Do something
                    break;
            }
        }
    }
