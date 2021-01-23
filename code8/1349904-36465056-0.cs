        // git log HEAD..master --reverse
		public ICommitLog StalkerList {
			get {
				var filter = new CommitFilter { 
					SortBy = CommitSortStrategies.Reverse | CommitSortStrategies.Time,
					Since = master,
					Until = head.Tip,             
				};
				return repo.Commits.QueryBy (filter);
			}
		}
