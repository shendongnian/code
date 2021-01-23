    // Basic Regex pattern that only allows numbers, 
    // lower & upper alpha, underscore and space
    static public string pattern = "[^0-9a-zA-Z_ ]";
    static public string Sanitize(string input, string pattern, string replace)
    {
        if (input == null)
        {
            return null;
        }
        else
        {
            //Create a regular expression object
            Regex rx;
            rx = new Regex(pattern);
            // Use the replace function of Regex to sanitize the input string. 
            // Replace our matches with the replacement string, as the matching
            // characters will be the ones we don't want in the input string.
            return rx.Replace(input, replace);
        }
    }
