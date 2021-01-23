    private IQueryable<TravelRequestSummaryView> GetApprovalRequests(int approvalState)
    {
        IQueryable<TravelRequestSummaryView> trsv = null;
        try
        {
            var res = db.GetAllRequestsByWorkflowState(approvalState)
                .ToList<TravelRequestSummaryView>();
            trsv = res.AsQueryable();
        }
        catch (Exception ex)
        {
            sqlTraceManager.WriteTraceIf(ex, User.Identity.Name);
        }
        return trsv;
    }
