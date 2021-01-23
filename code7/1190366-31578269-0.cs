    public List<MyIssues> method(string result)
    {
        RootObject myresult = JsonConvert.DeserializeObject<RootObject>(result);
        List<MyIssues> returnResulttoReport = new List<MyIssues>();
        foreach (var item in myresult.issues)
        {
            issueKey = item.key ?? string.Empty;
            foreach (var commentitem in item.fields.comment.comments)
            {
                updated = commentitem.updated ?? string.Empty;
    
                MyIssues temp1 = new MyIssues {
                    Comments = new List<Comment>
                        {
                            new Comment() { Updated = updated }
                        },
                    Key = key };
                returnResulttoReport.Add(temp1);
            }
        }
        return returnResulttoReport;
    }
