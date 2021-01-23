    public string RemoveAccentsAndDiacritics(string s)
    {
        return string.Concat(
            s.Normalize(NormalizationForm.FormD)
             .Where(c => System.Globalization.CharUnicodeInfo.GetUnicodeCategory(c) !=
                         System.Globalization.UnicodeCategory.NonSpacingMark));
    }
