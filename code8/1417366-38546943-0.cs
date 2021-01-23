    public static class StringTrimExtensions
    {
         public static int CharactersTrimmed {get; private set;}
         
         public static string Trim(this string input)
         {
             var trimmed = input.Trim();
             CharactersTrimmed = CharactersTrimmed + (input.Length - trimmed.Length);
             return trimmed;
         }
    }
