    public static Dictionary<int, Func<AuctionInfo, bool>> Presedence = 
                new Dictionary<int, Func<AuctionInfo, bool>>
    {
        { 0, a => a.WorkflowStage == LIVE_WORKFLOW_STAGE },
        { 1, a => a.WorkflowStage == OPEN_WORKFLOW_STAGE },
        { 2, a => a.StartDate >= DateTime.UtcNow },
    };
    
    //in your GetCurrentAuction()
    return Auctions.Where(a => Presedence.Any(p => p.Value(a)))
                    .OrderBy(a => Presedence.First(p => p.Value(a)).Key)
                    .ThenBy(a => a.StartDate)
                    .FirstOrDefault();
