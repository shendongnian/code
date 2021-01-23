    public async Task<IList<CreateCaseOutput>> CreateCase(
        CreateCaseInput createCaseInput,
        SaveCaseSearchInput saveCaseSearchInput)
    {
        // Omitted for brevity...
        var AcctLst = 
            await rep.ExecuteStoredProcedureAsync<CreateCaseOutput>(
                strSPQuery,
                listParam)
               .ToList();
    
        if (!string.IsNullOrEmpty(AcctLst.ElementAt(0).o_case_seq.ToString()))
        {
            await SaveCaseSearch(saveCaseSearchInput,
                           AcctLst.ElementAt(0).o_case_seq)
                .ContinueWith(r => Console.WriteLine(r.Result));
        }
        Console.WriteLine("After the async call");
        return AcctLst;
    }
