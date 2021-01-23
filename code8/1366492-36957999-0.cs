    public void UpdateStatus(int planId, string message)
    {
    	var clients = GlobalHost.ConnectionManager.GetHubContext<PlanHub>().Clients;
    	clients.All.updateStatus(planId, message);
    }
