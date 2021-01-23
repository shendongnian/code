    class QueryNotification
        {
            public DataSet DataToWatch { get; set; }
            public SqlConnection Connection { get; set; }
            public SqlCommand Command { get; set; }
    
            public string GetSQL()
            {
                return "SELECT * From YourTable";
            }
    
            public string GetConnection()
            {
                return ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            }
    
            public bool CanRequestNotifications()
            {
    
                try
                {
                    var perm = new SqlClientPermission(PermissionState.Unrestricted);
                    perm.Demand();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
    
            public void GetData()
            {
                DataToWatch.Clear();
                Command.Notification = null;
                var dependency =
                    new SqlDependency(Command);
                dependency.OnChange += dependency_OnChange;
    
                using (var adapter =
                    new SqlDataAdapter(Command))
                {
                    adapter.Fill(DataToWatch, "YourTableName");
                }
            }
    
            private void dependency_OnChange(object sender, SqlNotificationEventArgs e)
            {
    
                var i = (ISynchronizeInvoke)sender;
    
                if (i.InvokeRequired)
                {
    
                    var tempDelegate = new OnChangeEventHandler(dependency_OnChange);
    
                    object[] args = { sender, e };
    
                    i.BeginInvoke(tempDelegate, args);
    
                    return;
                }
    
                var dependency = (SqlDependency)sender;
    
                dependency.OnChange -= dependency_OnChange;
    
                GetData();
            }
    
    
        }
