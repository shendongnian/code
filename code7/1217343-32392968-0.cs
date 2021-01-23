    var TicketDetails = (from issuecases in caseModelDatabase.IssueCases
                               where ( (DbFunctions.TruncateTime(issuecases.CreatedDate) >= DbFunctions.TruncateTime(IssueDetails.StartDate)
                               && DbFunctions.TruncateTime(issuecases.CreatedDate) <=  DbFunctions.TruncateTime(IssueDetails.ToDate))
    
                               || ((!string.IsNullOrEmpty(IssueDetails.TicketArea) && issuecases.TicketArea.Equals(IssueDetails.TicketArea))
                               || (!string.IsNullOrEmpty(IssueDetails.TicketType) &&  issuecases.TicketType.Equals(IssueDetails.TicketType))
                               || (!string.IsNullOrEmpty(IssueDetails.Status) &&  issuecases.Status.Equals(IssueDetails.Status))))
                               select new { 
    
                                   issuecases.WorkRequestId,
                                   issuecases.Summary,
                                   issuecases.Status,
                                   issuecases.CreatedDate,
                                   issuecases.UpdatedDate
                               }).ToList();
