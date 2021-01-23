    private void SQLTest()
    {
        //Set up a sync context back to this main UI thread
        m_sql.SyncContext = SynchronizationContext.Current;
    
        //Being called from main UI thread 9
        m_sql.SQLErrorMessage = "FIRST CHANGE";
        Task<SQLConnectionProperties> taskConnect = Task.Factory
            .StartNew(() => threadConnect(m_sql), CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default)
            .ContinueWith((task) => threadConnect(task.Result, true));
        //Continue back to main UI (still in main UI thread 9)
    }
    
    private SQLConnectionProperties threadConnect(SQLConnectionProperties sql, bool bContinuation = false)
    {
        if (!bContinuation)
        {
            //In new thread 10
            sql.SQLErrorMessage = "SECOND CHANGE";
        }
        else
        {
            //In new thread 11
            sql.SQLErrorMessage = "THIRD CHANGE";
    
            sql.SyncContext.Post(threadConnectComplete, sql);
        }
        return sql;
    }
    
    private void threadConnectComplete(object state)
    {
        //Back in the main UI thread!  Save the changes to the sql object
        SQLConnectionProperties sql = state as SQLConnectionProperties;
        m_sql = sql;
    
        //See the results and use this area to update the main UI
        Debug.WriteLine("SQLErrorMessage:" + sql.SQLErrorMessage);
    
        //TESTING NON THREAD SAFE just to show you no runtime errors happen
        form_MainUI.textbox1.Text = sql.SQLErrorMessage;
    }
