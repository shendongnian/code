              var query = db.Feedbacks.Select(f = > new
                    {
                        businessId = s.Account.Businesses.FirstOrDefault().businessId,
                        hireSuccess = s.hireSuccess.Value,
                        useAgain = s.useAgain.Value,
                        suggestions = s.suggestions.Value,
                        numEmployees = s.numEmployees.Value
                    }).ToList();
              var result = query
                  .Select(s => new FeedbackViewModel
                    {
                        businessId = s.businessId,
                        hireSuccess = s.hireSuccess,
                        useAgain = s.useAgain,
                        suggestions = s.suggestions,
                        employees = numberGroups[s.numEmployees]
                    }).ToList();
