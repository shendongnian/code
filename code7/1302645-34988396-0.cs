    private IEnumerable<SelectListItem> statuses(string defaultStatus)
    {
       return db.JobStatus.Select(s => new SelectListItem
        {
            Value = s.JobStatusID.ToString(),
            Text = s.JobStatusName, 
            Selected = s.JobStatusName == defaultStatus
        }).ToList();
    }
