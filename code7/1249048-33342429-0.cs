      List<string> wordslist=new List<string>();//global declaration 
        while ((s = sw.ReadLine()) != null)
                {
                    string[] words = s.Split('*');
                    foreach(string word in words)
                    {
                     wordslist.Add(word);
                    }
                }
