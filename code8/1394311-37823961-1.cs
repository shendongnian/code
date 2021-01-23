    string RemoveDiacritics(string s)
    {
        var decomposed = s.Normalize(NormalizationForm.FormD);
        var sb = new StringBuilder();
        for (int i = 0; i < decomposed.Length; i++)
        {
            var category = CharUnicodeInfo.GetUnicodeCategory(decomposed, i);
            if (category != UnicodeCategory.NonSpacingMark)
                sb.Append(decomposed[i]);
        }
        return sb.ToString().Normalize(NormalizationForm.FormC);
    }
