    public static string FormatCaseConvention(string text)
    {
        string text = "SQLDataABCHumaAdADScVascASCasASCasASCTumEKa";
        var formatted = String.Empty;
        int i = 0;
        var totalLeangth = text.Length;
        foreach (char letter in text)
        {
            if (Char.IsUpper(letter) && i < totalLeangth - 1)
            {
                if (char.IsLower(text[i + 1]) && char.IsLower(text[i - 1]))
                    formatted += letter;
                else if (char.IsLower(text[i + 1]))
                    formatted += " " + letter;
                else
                    formatted += letter;
            }
            else if (i == totalLeangth - 1)
            {
                if (Char.IsUpper(letter) && char.IsUpper(text[i - 1]))
                    formatted += letter;
				
                else if(Char.IsUpper(text[i-1]))                
                    formatted += letter;                
					
				else				
					formatted += " " + letter;				
            }
            else if (Char.IsLower(letter) && char.IsUpper(text[i + 1]))
            {
                formatted += letter + " ";
            }
            else
            {
                formatted += letter;
            }
            i = i + 1;
        }
    }
