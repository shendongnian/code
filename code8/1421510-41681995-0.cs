        string headerText = Text.Substring(0, Text.Length < 150 ? Text.Length : 150);
        foreach (var searchText in upperDocTypes)
        {
            if (headerTextUpper.Contains(searchText))
            {
                DocumentType = docs.DocumentType;
                Vault = docs.VaultName;
                break;
            }
        }
