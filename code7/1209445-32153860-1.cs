    /// <summary>
    /// A hub for sending alerts to users.
    /// </summary>
    public class AlertHub : HubBase, IAlertHub {
        /// <summary>
        /// Sends the alert.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="userId">The user identifier.</param>
        public void SendAlert(string message, Guid userId) {
            HubUser user;
            Users.TryGetValue(userId, out user);
            if (user != null) {
                IHubContext context = GlobalHost.ConnectionManager.GetHubContext<AlertHub>();
                context.Clients.Clients(user.ConnectionIds.ToList()).sendAlert(message);
            }
        }
        /// <summary>
        /// Send alert to user.
        /// </summary>
        /// <param name="returnId">The return identifier.</param>
        /// <param name="userId">The user identifier.</param>
        public void ReturnProcessedAlert(Guid returnId, Guid userId) {
            HubUser user;
            Users.TryGetValue(userId, out user);
            if (user != null) {
                IHubContext context = GlobalHost.ConnectionManager.GetHubContext<AlertHub>();
                context.Clients.Clients(user.ConnectionIds.ToList()).returnProcessedAlert(returnId);
            }
        }
    }
