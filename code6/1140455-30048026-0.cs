    public bool IsPasswordValid(string password)
    {
        return password.Length >= 8 &&
               password.Length <= 15 &&
               password.Any(char.IsDigit) &&
               password.Any(char.IsLetter) &&
               (password.Any(char.IsSymbol) || password.Any(char.IsPunctuation)) ;
    }
