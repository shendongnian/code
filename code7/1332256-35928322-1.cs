    var counts = (from a in dc.tblMemberIssues
        join b in dc.vwMembers on a.MemberID equals b.MemberID
        where a.IssueID == issueID).ToList();
    var results = new
    {
        HaveCount = counts.Count(e => e.HaveCount != 0),
        WantCount = counts.Count(e => e.WantCount != 0),
        SaleCount = counts.Count(e => e.SaleCount != 0)
    };
