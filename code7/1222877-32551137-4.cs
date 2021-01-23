    static bool IsPalindrome(string word)
    {
         if (String.IsNullOrEmpty(word))
             return false;
         return word == String.Join("", word.Reverse());
    }
