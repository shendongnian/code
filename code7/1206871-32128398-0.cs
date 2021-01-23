    ProcessOMBCaseByCaseId(Int32 caseid)
    {
        using (AWCTSDBEntities context = new AWCTSDBEntities())
        {
            var caseRecQuery = (from c in context.Cases
                                where (c.CaseId == caseId && c.SystemTypeCode == SystemCodes.OMB)
                                select c).OfType<OMBCase>(); 
            Logic logic logic; // Logic performed on case
        }
    }
    
