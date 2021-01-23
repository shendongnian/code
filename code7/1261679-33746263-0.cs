    public static class ChatReader
    {
        static string pattern = @"\d\d\.\d\d\.\d\d\d\d, \d\d:\d\d - .*?:";        
        static Regex rgx = new Regex(pattern);
        static string prevLine = "";
        static string currLine = "";
        public static IEnumerable<string> ReadChatMessages(this TextReader reader)
        {
            prevLine = reader.ReadLine();
            currLine = reader.ReadLine();
            bool isPrevChatMsg = rgx.IsMatch(prevLine);                
            while (currLine != null)
            {
                bool isCurrChatMsg = rgx.IsMatch(currLine);
                if (isPrevChatMsg && isCurrChatMsg)
                {
                    yield return prevLine;
                    prevLine = currLine;                    
                }
                else if (isCurrChatMsg)
                {
                    yield return currLine;
                    prevLine = currLine;
                }
                else
                {
                    prevLine += '\n' + currLine;
                }
                currLine = reader.ReadLine();
             
            }
            yield return prevLine;
            
        }
    }
