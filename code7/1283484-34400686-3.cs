    var result = db.Status
                   .GroupBy(s=>s.UserId)
                   .Select(gr=>
                   {
                       // Generally you should avoid use the First
                       // and you should use the FirstOrDefault
                       // but in this context is safe to use First.
                       var mostRecentComplaint = gr.OrderByDescending(k=> k.DateTime)
                                                   .First();
                       return new Complaint_DTO
                       {
                           ComplaintId = gr.Key,
                           Status = mostRecentComplaint.Status,
                           CreatedDate = mostRecentComplaint.CreatedDate
                       }
                   }; 
