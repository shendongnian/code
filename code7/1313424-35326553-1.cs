    var query = (from c in DOCCCOIssues//.IssuesModels
                group c by c.Comment into g
                select new
                {
                    Comment = g.Key,
                    Count = g.Count()
                });
