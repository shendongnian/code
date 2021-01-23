    bool ContainsOnlyNumbers( string input )
    {
      // beginning of string, one or more digits, end of string
      return Regex.IsMatch( input, @"^\d+$" );
    }
    
    bool ContainsOnlyLetters( string input )
    {
      // beginning of string, one or more letters, end of string
      return Regex.IsMatch( input, @"^[A-Za-z]+$" );
    }
