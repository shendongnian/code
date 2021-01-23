       public static void Main()
       {
          string pattern = "a*";
          string input = "abaabb";
    
          Match m = Regex.Match(input, pattern);
          while (m.Success) {
             Console.WriteLine("'{0}' found at index {1}.", 
                               m.Value, m.Index);
             m = m.NextMatch();
          }
       }
