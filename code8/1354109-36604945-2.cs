    public Task<SaveCaseSearchOutput> SaveCaseSearch(
        SaveCaseSearchInput saveCaseSearchInput,
        long? caseKey)
    {
        var rep = new Repository();
        var query = string.Empty;
        var listParam = new List<object>();
        SQL.CaseSQL
           .getSaveCaseSearchParameters(
               saveCaseSearchInput, 
               caseKey, 
               out query,
               out listParam);
        return rep.ExecuteStoredProcedureAsync<SaveCaseSearchOutput>(
            strSPQuery, 
            istParam);
    }
