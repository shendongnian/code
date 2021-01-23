        static string removeTagsInBrackets(string input)
        {            
            StringBuilder sb = new StringBuilder(input.Length);
            bool insideBrackets = false;
            bool insideTag = false; char c;
            int indexOfLast = input.LastIndexOf(']');
            for (int i = 0; i < input.Length; i++)
            {
                c = input[i];
                if (c == '[') { insideBrackets = true; sb.Append(c); continue; }
                if (i == indexOfLast) { insideBrackets = false; sb.Append(c); continue; }
                if (c == '<' || c == '>') { insideTag = !insideTag; }
                if (insideBrackets) if (insideTag || (!insideTag && c == '>')) continue;
                sb.Append(c);
            }
            return sb.ToString();
        }
