    public bool IsTwoDigitsHexNumber(string s) {
        return !string.IsNullOrEmpty(s) &&
            s.Length <= 2 &&
            s.All(c => c >= '0' && c <= '9' || c >= 'A' && c <= 'F');
    }
