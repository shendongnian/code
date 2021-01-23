    public bool IsAccentedLetter(char c)
    {
        // I'm afraid this does NOT really do the job
        return CharUnicodeInfo.GetUnicodeCategory(c) == UnicodeCategory.NonSpacingMark;
    }
