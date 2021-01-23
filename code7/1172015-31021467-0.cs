     public CygnusInternalResponseViewModel GetAllTimeEntriesForGrid(int start = 0, int perPage = -1, string sortColumn = "", string sortDirection = "")
        {
            List<TimeEntryViewModel> te = new List<TimeEntryViewModel>();
            var query=_DBContex.TimeEntries.ToList();//create in-memory representation
            te = (from jb in query
                 select new TimeEntryViewModel
                 {
                     Id = jb.Id,
    
                     ResourceId = (int)jb.ResourceId,
                     TicketId = (int)jb.TicketId,
                     WorkType = (WorkTypeCatalog)jb.WorkType,
                     HoursWorked = (float)jb.HoursWorked,
                     Status = (TimeEntryStatusCatalog)jb.Status,
                     Role = (RoleCatalog)jb.Role,
                     StartTime = (TimeSpan)jb.StartTime,
                     EndTime = (TimeSpan)jb.EndTime,
                     SummaryNotes = jb.SummaryNotes,
                     InternalNotes = jb.InternalNotes,
                     Contract = (DateTime)jb.Contract,
                     Date = (DateTime)jb.Date,
                     ResourceName = GetResourceNameById((int)jb.ResourceId)   
                 }).ToList();
