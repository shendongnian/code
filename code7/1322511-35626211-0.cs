    if (NoPropIsNullOrEmpty())
    {
    }
    private bool NoPropIsNullOrEmpty()
    {
        return !(string.IsNullOrEmpty(primaryObj.Identifiers?.Id2) ||
                 string.IsNullOrEmpty(primaryObj.Identifiers?.Id2) ||
                 string.IsNullOrEmpty(primaryObj.Identifiers?.Id3) ||
                 string.IsNullOrEmpty(primaryObj.Identifiers?.Id4) ||
                 string.IsNullOrEmpty(primaryObj.Identifiers?.Id5) ||
                 string.IsNullOrEmpty(primaryObj.Identifiers?.Id6) ||
                 string.IsNullOrEmpty(primaryObj.Identifiers?.Id7) ||
                 string.IsNullOrEmpty(primaryObj.Identifiers?.Id8));
    }
