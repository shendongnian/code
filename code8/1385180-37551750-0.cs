    bool IsKeyword(string s)
    {
        var cscp = new CSharpCodeProvider();
        return s != null
               && CodeGenerator.IsValidLanguageIndependentIdentifier(s)
               && s.Length <= 512
               && !cscp.IsValidIdentifier(s);
    }
