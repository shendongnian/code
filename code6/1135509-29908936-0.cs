    IQueryable<Jobs> GetJobs(list<string> staff, list<string> clients)
    {
        var query = dbContext.Jobs.Where(x => x.JobName.Contains("New Job"));
        if (staff != null && staff.Count > 0)
            query = query.Where(x => staff.Contains(x.Staff));
        if (clients != null && clients.Count > 0)
            query = query.Where(x => x.Clients.Any(c => clients.Contains(c.Name)));
        return query;
    }
