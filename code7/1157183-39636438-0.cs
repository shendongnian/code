    static readonly Regex Validator = new Regex(@"^[&]+$");
    
    public static bool IsValid(string str) {
        return Validator.IsMatch(str);
    }
