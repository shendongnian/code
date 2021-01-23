    string formDString = txt.Normalize(NormalizationForm.FormD);
            
    var sb = new StringBuilder();
    var len = formDString.Length;
    for (int i = 0; i < len; i++)
    {
        var formDChar = formDString[i];
        System.Globalization.UnicodeCategory category = System.Globalization.CharUnicodeInfo.GetUnicodeCategory(formDChar);
        if (category != System.Globalization.UnicodeCategory.NonSpacingMark)
        {
            sb.Append(formDChar);
        }
    }
