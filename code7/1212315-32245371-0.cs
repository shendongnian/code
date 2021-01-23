    public static bool IsPalindrome(String text)
    {
        if(string.IsNullOrWhiteSpace(text))
               return false;
    
        char[] arr = text.ToCharArray();
    	Array.Reverse(arr);
    	var reversedText = new string(arr);         
        return string.Equals(text, reversedText, StringComparison.OrdinalIgnoreCase);
    }
