    static string RemoveAccents(string text) 
    {
        var normalized = text.Normalize(NormalizationForm.FormD);
        var builder = new StringBuilder();
    
        foreach (var character in normalized)
        {
            var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(character);
            if (unicodeCategory != UnicodeCategory.NonSpacingMark)
            {
                builder.Append(character);
            }
        }
    
        return builder.ToString().Normalize(NormalizationForm.FormC);
    }
