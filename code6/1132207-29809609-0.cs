    private char[] identifiers = { /* Your identifiers*/ };
    public bool DoesContain(string containingString)
    {
        return containingString.ToCharArray().Any(c => identifiers.Contains(c));
    }
