    var tw = workers.Select(x => new
                {
                    Id = x.Id,
                    JobOpportunityFeedbacks = x.JobOpportunityFeedbacks.AsEnumerable().
                    Select(y => new
                    {
                        Rating = SqlFunctions.StringConvert(y.Rating, 4, 2)
                        Feedback = y.Feedback
                    });
