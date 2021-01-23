    string str = "Hèållo"; // Doesn't work with æ, ø
    int gemValue = 0;
    string str2 = string.Concat(
        str.Normalize(NormalizationForm.FormD)
           .Where(x => CharUnicodeInfo.GetUnicodeCategory(x) != UnicodeCategory.NonSpacingMark));
    for (int i = 0; i < str.Length; i++)
    {
        char ch = str2[i];
        if (ch >= 'A' && ch <= 'Z')
        {
            gemValue += ch - 'A' + 1;
        }
        else if (ch >= 'a' && ch <= 'z')
        {
            gemValue += ch - 'a' + 1;
        }
        else if (char.IsLetter(ch))
        {
            throw new NotSupportedException(string.Format("{0} contains non A-Z letters", str));
        }
    }
