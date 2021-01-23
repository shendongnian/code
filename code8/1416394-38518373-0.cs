    var query = from rating in ratings
                group rating by rating.ArticleTitle into results
                from g in results
                select new
                {
                    Title = g.Key,
                    Yes = g.Count(r => r.Useful),
                    No = g.Count(r => !r.Useful)
                };
