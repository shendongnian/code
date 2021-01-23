    var groupedResults = (from co in Complaints
        join p in Projects on co.ProjectId equals p.ProjectId 
        join cont in Contacts on co.SubContractorContactId equals cont.ContactId
        join cont2 in Contacts on co.OccupanttContactId equals cont2.ContactId
                select new
                {
                    ProjecttName =  p.Name,
                    ComplaintId =   co.Id,                                 
                    SubContractorName = cont.FirstName,
                    OccupantName = cont2.FirstName
                    // Fill the other properties here please                                  
                }
    ).GroupBy(k => k.ProjecttName, i => i, (x, b) => new
    {
        Project=x,
        Complaints =b.Select(d=> new 
        {
            CompId=d.ComplaintId,
            Contacts=new  { SubContr=d.SubContractorName, Occupant = d.OccupantName}  
        })
    }).ToList();
