    public static String SeparateTitleCase(this string input, string delimiter = " ")
    {
        StringBuilder sb = new StringBuilder();
        bool wasLower = false;
        for(int i = 0; i < input.Length; i++)
        {
            var charType = Char.GetUnicodeCategory(input[i]);
            if (charType == UnicodeCategory.LowercaseLetter) 
                wasLower = true;
            else
            {
                if(wasLower && (charType == UnicodeCategory.UppercaseLetter || charType == UnicodeCategory.TitlecaseLetter))
                    sb.Append(delimiter);
                wasLower = false;
            }
            sb.Append(input[i]);
        }
        return sb.ToString();
    }
