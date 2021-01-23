    var counts = (from a in dc.tblMemberIssues
                  join b in dc.vwMembers on a.MemberID equals b.MemberID
                  where a.IssueID == issueID
                  group a by true into d
                  select new
                  {
                      HaveCount = d.Count(e => e.HaveCount != 0),
                      WantCount = d.Count(e => e.WantCount != 0),
                      SaleCount = d.Count(e => e.SaleCount != 0)
                  }).First();
