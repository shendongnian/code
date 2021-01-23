    public ICommitLog CommitList {
        get {
            var filter = new CommitFilter { 
                SortBy = CommitSortStrategies.Reverse | CommitSortStrategies.Time,
                Since = repo.Branches.Single (branch => branch.FriendlyName == "bugfix1234");
                Until = repo.Branches.Single (branch => branch.FriendlyName == "master");           
            };
            return repo.Commits.QueryBy (filter);
        }
    }
