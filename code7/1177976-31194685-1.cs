        static string removeTagsInBrackets(string input)
        {
            string temp = input.Split('[').Last().Split(']').First();
            int numberOfBrackets = input.Count(c => c == '[');            
            string result = input.Split('[').First() + new String('[', numberOfBrackets); 
            bool isTag = false;            
            for (int i = 0; i < temp.Length; i++)
            {
                if (temp[i] == '<' || temp[i] == '>') { isTag = !isTag; continue; }                
                if (!isTag) result += temp[i];
            }
            result += new String(']', numberOfBrackets) + input.Split(']').Last();            
            return result;
        }
