    private static string GenerateClassName(string value)
    {
        string className = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value);
        bool isValid = Microsoft.CSharp.CSharpCodeProvider.CreateProvider("C#").IsValidIdentifier(className);
        if (!isValid)
        { 
            // File name contains invalid chars, remove them
            Regex regex = new Regex(@"[^\p{Ll}\p{Lu}\p{Lt}\p{Lo}\p{Nd}\p{Nl}\p{Mn}\p{Mc}\p{Cf}\p{Pc}\p{Lm}]");
            className = regex.Replace(className, "");
            // Class name doesn't begin with a letter, insert an underscore
            if (!char.IsLetter(className, 0))
            {
                className = className.Insert(0, "_");
            }
        }
        return className.Replace(" ", string.Empty);
    }
