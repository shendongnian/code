    private static readonly Dictionary<string, string> TableNameTranslations
        = new Dictionary<string, string>
    {
        { "ORDR", "Client order document" },
        { "OINV", "Invoice document" },
        { "OPRQ", "Purchase quotation" }
    };
    ...
    public string GetClientDocumentDisplayString(int clientId)
    {
        var tableNames = GetTableNamesForClient(clientId);
        var translatedNames = tableNames.Select(t => TableNameTranslations[t]);
        return $"Client with ID:{clientId} has documents: {string.Join(",", translatedNames)}";
    }
    private IList<string> GetTableNamesForClient(int clientId)
    {
        // Whatever your code needs, returning ORDR, OINV etc
    }
