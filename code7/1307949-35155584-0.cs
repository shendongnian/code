    public static ICollection<CaseEntityType> GetCaseListTiny<CaseEntityType>(string queryComment) where CaseEntityType : CaseEntityBase
    {
        using (var context = AppKernel.Get<ICaseContext>())
        {
            var grantedCaseTypesIDs = AppEnvironment.CurrentUser.CaseTypesGranted.Select(casetype => casetype.ID).ToList();
            var cases = context.GetAllIncluding<TaskEntityType>(AppEnvironment.CurrentUser, queryComment, LogAction.Read, t => t.CaseType
                ).Where(t => grantedTaskTypesIDs.Contains(t.CaseType.ID)).ToList();
            int count = cases.Count(); // or Count<T>();
            return cases;
        }
    }
