    public static int FindFullWord(this string search, string word)
    {
        if (search == word || search.StartsWith(word + " "))
        {
            return 0;
        }
        else if (search.EndsWith(" " + word))
        {
            return search.Length - word.Length;
        }
        else if (search.Contains(" " + word + " "))
        {
            return search.IndexOf(" " + word + " ") + 1;
        }
        else {
            return -1;
        }
    }
