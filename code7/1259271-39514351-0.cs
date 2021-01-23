    public static int IndexOfLongestRun(string str)
        {
            Dictionary<string, int> letterCount = new Dictionary<string, int>();
           
            for (int i = 0; i < str.Length; i++)
            {
                string c = str.Substring(i, 1);                       
    
                if (letterCount.ContainsKey(c))
                
                    letterCount[c]++;
                else
                
                    letterCount.Add(c, 1);
            }
    
            return letterCount.Values.Max();
        }
