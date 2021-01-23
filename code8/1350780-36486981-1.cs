    List<ClientIssuesUpdate> updates = this.db.ClientIssuesUpdates.Where(i    => i.IssueId == issueId).ToList().OrderByDescending(p => p.CreatedDate);
    foreach (var comment in updates.Where(comment => comment.Children != null))
            {
                // order the children
                comment.Children = new List<Comment>(comment.Children.OrderByDescending(c => c.CreatedDate));
            }
    
