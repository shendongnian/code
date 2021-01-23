    var since = new DateTimeOffset(DateTime.Now.AddDays(-7));
    var until = new DateTimeOffset(DateTime.Now.AddDays(-2));
    var filteredCommitLog = commitLog.Where(c => c.Committer.When > since && c.Committer.When < until);
    foreach (Commit commit in filteredCommitLog)
    {
    	Console.WriteLine("{0} : {1}", commit.Committer.When.ToLocalTime(), commit.MessageShort);
    }
