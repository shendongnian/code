    public static TemplateData ReturnData(string schemeCode = null)
    {
        string sqlInstructionCstmID = "SELECT TOP(1) LetterTemplateCustomisationId, TemplateId, Logo, SchemeCode, Version, Comment FROM LetterTemplateCustomisation;
        if (!string.IsNullOrEmpty(schemeCode))
        {
            sqlInstructionCstmID += " WHERE SchemeCode ='" + schemeCode + "'";
        }
