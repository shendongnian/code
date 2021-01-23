    public List<JobCurrentStatusDetails> NotifyUpdates()
    {
       var hubContext = lobalHost.ConnectionManager.GetHubContext<JobDetailsHub>();
       if (hubContext != null)
       {
           db =  DataAccess.DataAccessModels.GetDashboardCounts();
           return hubContext.Clients.All.updateData(db).Result;
       }
       else return null;
    }
