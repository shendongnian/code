        public ActionResult SignalR(String Message, String Type, String ConnectionId)
        {
            if (!String.IsNullOrWhiteSpace(Message) && !String.IsNullOrWhiteSpace(Type) && !String.IsNullOrWhiteSpace(ConnectionId))
            {
                if (Type == "ShowAlert")
                {
                    // Determine if the user that started the process is still online
                    bool UserIsOnline = Hubs.TestHub.UsersOnline.ContainsKey(ConnectionId);
                    // We need this to execute our client methods
                    IHubContext TestHub = GlobalHost.ConnectionManager.GetHubContext<Hubs.TestHub>();
                    if (UserIsOnline)
                    {
                        // Show the alert to only the client that started the process.
                        TestHub.Clients.Client(ConnectionId).showAlert(Message);
                    } // end if
                    else
                    {
                        List<String> UserIdsInRole = new List<String>();
                        using (var connection = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString()))
                        {
                            // Assuming you're using Identity framework since it is an MVC project, get all the ids for users in a given role.
                            // This is using Dapper
                            UserIdsInRole = connection.Query<String>(@"
    SELECT                  ur.UserId
    FROM                    AspNetUserRoles ur
    JOIN                    AspNetRoles r ON ur.RoleId = r.Id
    WHERE                   r.Name = @rolename
    ", new { rolename = "SpecialRole" }).ToList();
                        } // end using
                        // Find what users from that role are currently connected
                        List<String> ActiveUsersInRoleConnectionIds = Hubs.TestHub.UsersOnline.Where(x => UserIdsInRole.Contains(x.Value)).Select(y => y.Key).ToList();
                        // Send the message to the users in that role who are currently connected
                        TestHub.Clients.Clients(ActiveUsersInRoleConnectionIds).showAlert(Message);
                    } // end else (user is not online)
                } // end if type show alert
            } // end if nothing is null or whitespace
            return new HttpStatusCodeResult(200);
        } // end SignalR
