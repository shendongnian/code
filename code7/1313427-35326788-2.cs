    List<IssuesModel> issueModel = new List<IssuesModel>();
	foreach (var s in query)
	{
		IssuesModel issue = new IssuesModel();
		issue.Comment = s.Comment;
		issue.Count = s.Count;
		issueModel.Add(issue);		
	}
	
	
	issueModel.Dump(); 
