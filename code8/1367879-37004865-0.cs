    var tw = workers.Select(x => new
        {
            Id = x.Id,
            JobOpportunityFeedbacks = x.JobOpportunityFeedbacks
                .Select(y => new
                {
                    y.Rating,
                    y.Feedback
                })
        })
        .AsEnumerable()
        .Select(x => new 
            {
                x.Id,
                JopOpertunityFeedbacks = x.JobOpportunityFeedbacks
                    .Select(y => new
                    {
                        Rating = String.Format("0.00",y.Rating),
                        y.Feedback
                    })
            });
