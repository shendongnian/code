    private static readonly HashSet<UnicodeCategory> SeparatorCharCategories = new HashSet<UnicodeCategory>{ UnicodeCategory.UppercaseLetter, UnicodeCategory.TitlecaseLetter, UnicodeCategory.DecimalDigitNumber };
    public static String SeparateCharCategories(this string input, string delimiter = " ")
    {
        StringBuilder sb = new StringBuilder(input.Length);
        UnicodeCategory lastCharCategory = Char.GetUnicodeCategory(input[0]);
        for(int i = 0; i < input.Length; i++)
        {
            UnicodeCategory charCategory = Char.GetUnicodeCategory(input[i]);
            if (lastCharCategory != charCategory && SeparatorCharCategories.Contains(charCategory))
                sb.Append(delimiter);
            sb.Append(input[i]);
            lastCharCategory = charCategory;
        }
        return sb.ToString();
    }
