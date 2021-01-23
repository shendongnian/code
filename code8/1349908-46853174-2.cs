     // git log HEAD..master --reverse
    public ICommitLog StalkerList {
        get {
            var filter = new CommitFilter { 
                SortBy = CommitSortStrategies.Reverse | CommitSortStrategies.Time,
                Since = head.Tip,
                Until = master       
            };
            return repo.Commits.QueryBy (filter);
        }
    }
