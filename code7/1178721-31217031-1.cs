    static void Main(string[] args)
    {
          string SingleStringHere = "\"word1\", \"word2\", \"word3\"";
          string[] data = ParseSingleString(SingleStringHere);
          foreach(string s in data)
          {
                Console.WriteLine(s);
          }
    }
    public static string[] ParseSingleString(string singleString)
    {
          List<string> multipleStrings = new List<string>();
          StringBuilder current = new StringBuilder();
          bool inQuote = false;
          for(int index = 0; index < singleString.Length; ++index) // iterate through the string
          {
                if (singleString[index] == '"')
                {
                       inQuote = !inQuote;
                }
                else if (!inQuote && singleString[index] == ',') // split at comma if not in quote
                {
                       multipleStrings.Add(current.ToString().Trim());
                       current.Clear();
                }
                else
                {
                       current.Append(singleString[index]);
                }
          }
          multipleStrings.Add(current.ToString()); // don't forget the last one
          return multipleStrings.ToArray();
    }
