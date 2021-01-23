		var since = new DateTimeOffset(DateTime.Now.AddDays(-7));
		var until = new DateTimeOffset(DateTime.Now.AddDays(-2));
		var filteredCommitLog = commitLog.Where(c => c.Committer.When > since && c.Committer.When < until);
		foreach (Commit commit in filteredCommitLog)
		{
			Console.WriteLine("{0} : {1}", commit.Committer.When.ToLocalTime(), commit.MessageShort);
			foreach (var parent in commit.Parents) {
				foreach (TreeEntryChanges change in repo.Diff.Compare<TreeChanges>(parent.Tree, commit.Tree)) {
					Console.WriteLine ("\t{0} :\t{1}", change.Status, change.OldPath);
				}
			}
		}
