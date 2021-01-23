    int counter = 0; //initialization of help counter
    [System.Web.Services.WebMethod]
    
        public static IEnumerable<AttendeeList> GetAllUsers()
        {
            var AttendeeList = new List<AttendeeList>();
    
            try
            {
                using (var connection = new SqlConnection(_connString))
                {
                    connection.Open();
                    string str = "";
                    str += "SELECT [AttendeeID], ";
                    str += "       [IsAllowToUploadDocuments],";
                    str += "       [IsOnline], ";
                    str += "       [AttendeeTypeName],";
                    str += "       [UserName] ";
                    str += "       FROM [dbo].[Meeting_Attendees]   ";
                    str += "       INNER JOIN [dbo].[aspnet_Users]  ON [aspnet_Users].[UserId] = [Meeting_Attendees].[AttendeeID] ";
                    str += "       INNER JOIN   [dbo].[AttendeeType] ON [dbo].[AttendeeType].[AttendeeTypeID] = [dbo].[Meeting_Attendees].[AttendeeTypeID] ";
                    str += "       WHERE [MeetingID]=@MeetingID ORDER BY [IsOnline] DESC";
    
                    using (var command = new SqlCommand(@str, connection))
                    {
                        SqlParameter prm = new SqlParameter("@MeetingID", SqlDbType.Int);
                        prm.Direction = ParameterDirection.Input;
                        prm.DbType = DbType.Int32;
                        prm.Value = Convert.ToInt32(Properties.Settings.Default.MeetingID);
                        command.Parameters.Add(prm);
                        command.Notification = null;
    
                        var dependency = new SqlDependency(command);
                        counter = 0; //Whenewer the web method is called, set te counter to 0
                        dependency.OnChange += new OnChangeEventHandler(dependencyUsers_OnChange);
    
                        if (connection.State == ConnectionState.Closed)
                            connection.Open();
    
                        var reader = command.ExecuteReader();
    
                        while (reader.Read())
                        {
                            AttendeeList.Add(item: new AttendeeList { UserName = (string)reader["UserName"], UserType = (string)reader["AttendeeTypeName"], IsOnline = (bool)reader["IsOnline"], IsAllowToUploadDocuments = (bool)reader["IsAllowToUploadDocuments"], IsCurrentUser = true ? (Guid)reader["AttendeeID"] == new Guid(Properties.Settings.Default.UserID.ToString()) : false });
                        }
                    }
                }
            }
            catch { }
            return AttendeeList;
        }
    
        private static void dependencyUsers_OnChange(object sender, SqlNotificationEventArgs e)
        {
                if (e.Type == SqlNotificationType.Change && e.Info == SqlNotificationInfo.Update && counter == 0)
                {
                    //Call SignalR  
                    MessagesHub.UpdateUsers();
                    counter++; //The update is done once
                }
                else 
                {
                    counter = 0; //if the update is needed in the same iteration, please don't update and set the counter to 0
                }
         }
