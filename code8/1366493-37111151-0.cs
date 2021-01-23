    public class PlanHub : Hub
    {
        private const string GroupPrefix = "PlanGroup_";
        
        // hubcontext
        private static IHubContext hubContext = GlobalHost.ConnectionManager.GetHubContext <PlanHub> ();
        public void Register(int companyId)
        {
            Groups.Add(Context.ConnectionId, $"{GroupPrefix}{companyId}");
        }
        public void Unregister(int companyId)
        {
            Groups.Remove(Context.ConnectionId, $"{GroupPrefix}{companyId}");
        }
        // static method using hub context
        public static void Static_UpdateStatus(int planId, string message)
        {
            hubContext.Clients.All.updateStatus(planId, message);
        }
    }
