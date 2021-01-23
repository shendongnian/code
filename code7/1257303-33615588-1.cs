    String password = "Aa!1asdetD"
    HashSet<char> specialCharacters = new HashSet<char>() { '!', '@', '%', '$', '#' };
    if (password.Any(char.IsLower) && //Lower case 
         password.Any(char.IsUpper) &&
         password.Any(char.IsDigit) &&
         password.Length > 8
         password.Any(specialCharacters.Contains))
    {
      //valid password
    }
