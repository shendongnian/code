    char[] chars = text.ToCharArray();
    int letterStart = Array.FindIndex(chars, c => Char.IsLetterOrDigit(c));
    int letterEnd = Array.FindLastIndex(chars, c => Char.IsLetterOrDigit(c));
    if (letterStart != letterEnd)
    {
        string before = text.Remove(letterStart);
        string after = text.Substring(letterEnd);
        string between = text.Substring(letterStart, letterEnd - letterStart);
        between = new string(between.Where(Char.IsLetterOrDigit).ToArray());
        text = string.Format("{0}{1}{2}", before, between, after);
    }
