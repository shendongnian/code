    /// <summary>
    /// base class for Hubs in the system.
    /// </summary>
    public class HubBase : Hub  {
        /// <summary>
        /// The hub users
        /// </summary>
        protected static ConcurrentDictionary<Guid, HubUser> Users = new ConcurrentDictionary<Guid, HubUser>();
        /// <summary>
        /// Called when the connection connects to this hub instance.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.Threading.Tasks.Task" />
        /// </returns>
        public override System.Threading.Tasks.Task OnConnected() {
            Guid userName = RetrieveUserId();
            string connectionId = Context.ConnectionId;
            HubUser user = Users.GetOrAdd(userName, _ => new HubUser {
                UserId = userName,
                ConnectionIds = new HashSet<string>()
            });
            lock (user.ConnectionIds) {
                user.ConnectionIds.Add(connectionId);
            }
            return base.OnConnected();
        }
        /// <summary>
        /// Called when a connection disconnects from this hub gracefully or due to a timeout.
        /// </summary>
        /// <param name="stopCalled">true, if stop was called on the client closing the connection gracefully;
        /// false, if the connection has been lost for longer than the
        /// <see cref="P:Microsoft.AspNet.SignalR.Configuration.IConfigurationManager.DisconnectTimeout" />.
        /// Timeouts can be caused by clients reconnecting to another SignalR server in scaleout.</param>
        /// <returns>
        /// A <see cref="T:System.Threading.Tasks.Task" />
        /// </returns>
        public override System.Threading.Tasks.Task OnDisconnected(bool stopCalled) {
            try {
                Guid userName = RetrieveUserId();
                string connectionId = Context.ConnectionId;
                HubUser user;
                Users.TryGetValue(userName, out user);
                if (user != null) {
                    lock (user.ConnectionIds) {
                        user.ConnectionIds.RemoveWhere(cid => cid.Equals(connectionId));
                        if (!user.ConnectionIds.Any()) {
                            HubUser removedUser;
                            Users.TryRemove(userName, out removedUser);
                        }
                    }
                }
            } catch {
                //Bug in SignalR causing Context.User.Identity.Name to sometime be null
                //when user disconnects, thus remove the connection manually.
                lock (Users) {
                    HubUser entry = Users.Values.FirstOrDefault(v => v.ConnectionIds.Contains(Context.ConnectionId));
                    if (entry != null) entry.ConnectionIds.Remove(Context.ConnectionId);
                }
            }
            return base.OnDisconnected(stopCalled);
        }
        private Guid RetrieveUserId() {
            Cookie authCookie = Context.Request.Cookies[FormsAuthentication.FormsCookieName];
            FormsAuthenticationTicket decryptedCookie = FormsAuthentication.Decrypt(authCookie.Value);
            var user = JsonConvert.DeserializeObject<User>(decryptedCookie.UserData);
            return user.Id;
        }
    }
