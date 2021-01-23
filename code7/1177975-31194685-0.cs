        static string removeTagsInBrackets(string input)
        {
            string temp = input.Split('[').Last().Split(']').First();
            string result = ""; bool isTag = false;
            for (int i = 0; i < temp.Length; i++)
            {
                if (temp[i] == '<') { isTag = true; continue; }
                if (temp[i] == '>') { isTag = false; continue; }
                if (!isTag) result += temp[i];
            }
            return result;
        }
