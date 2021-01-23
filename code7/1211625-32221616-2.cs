    public static String MiddleLetters(string value) {
      if (String.IsNullOrEmpty(value))
        return value; // middle of the "null" is supposed to be null 
      return value.Length % 2 == 0 ? 
         value.Substring(value.Length / 2 - 1, 2) 
       : value.Substring(value.Length / 2, 1);
    }
