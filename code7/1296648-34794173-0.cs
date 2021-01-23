        string str = "Hello, how are you?";
        string tmp = "";
        List<string> ListOfWords = new List<string>();
        int j = 0;
        for (int i = 0; i < str.Length; i++)
        {
            if (str[i] != ' ')
            {
                tmp = tmp + str[i];
                continue;
            }
            // here is the problem, i cant assign every tmp in the array
            ListOfWords.Add(tmp);
            tmp = "";
        }
        ListOfWords.Add(tmp);
