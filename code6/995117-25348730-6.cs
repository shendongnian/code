    if (!_queryNotification.CanRequestNotifications())
                {
                    MessageBox.Show("ERROR:Cannot Connect To Database");
                }
                
                SqlDependency.Stop(_queryNotification.GetConnection());
                SqlDependency.Start(_queryNotification.GetConnection());
    
                if (_queryNotification.Connection == null)
                {
                    _queryNotification.Connection = new SqlConnection(_queryNotification.GetConnection());
                }
    
                if (_queryNotification.Command == null)
                {
                    _queryNotification.Command = new SqlCommand(_queryNotification.GetSQL(),
    _queryNotification.Connection);
                }
                if (_queryNotification.DataToWatch == null)
                {
                    _queryNotification.DataToWatch = new DataSet();
                }
    
                GetData();
