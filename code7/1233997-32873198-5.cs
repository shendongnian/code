    public string ReplaceMethod(string input, Dictionary<string,string> dict1 )
    {
        StringBuilder output = new StringBuilder();
        //loop the string's characters
        for (int c = 0; c < input.Length; c++)
        {
           bool found = false;
           //order by length desc to ensure longest possible match is checked first
           foreach (KeyValuePair<string, string> item in
                                          dict1.OrderByDescending(x => x.Key.Length))
           {
               if (input.Substring(c).StartsWith(item.Key))
               {
                   //match found
                   found = true;
                   //skip length of the key
                   c+=item.Key.Length - 1;
                   output.Append(item.Value);
                   break;
                }
            }
            if (!found)
                output.Append(input[c]);
        }
        return output.ToString();
    }
