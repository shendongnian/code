    public class LiveData
    {
        public string SprocOrQuery { get; set; }
        private Dictionary<string, object> par = new Dictionary<string, object>();
        public Dictionary<string, object> Parameters { get { return par; } set { par = value; } }
        public string SqlConn { get; set; }
        public Action<DataTable> ActionOnData { get; private set; }
        public bool EffectedOnly { get; set; }
        public DateTime EffectDate = DateTime.Now;
        public int EffectedCyles { get; private set; }
        public DataTable Data { get; private set; }
        public List<SqlNotificationInfo> Events { get; set; }
        public SqlNotificationInfo CurrentEvent { get; private set; }
        public LiveData() { }
        public LiveData(string sprocOrQuery, Dictionary<string, object> parameters = null, string connection = null)
        {
            SprocOrQuery = sprocOrQuery;
            Parameters = parameters;
            SqlConn = connection;
        }
        public Task Start(Action<DataTable> actionOnData = null)
        {
            return Task.Factory.StartNew(() =>
            {
                try
                {
                    if (ActionOnData == null) ActionOnData = actionOnData;
                    SqlConnection sqlConn = new SqlConnection(SqlConn);
                    using (SqlCommand cmd = new SqlCommand(SprocOrQuery, sqlConn) { CommandType = SprocOrQuery.Contains(" ") ? CommandType.Text : CommandType.StoredProcedure, CommandTimeout = 60 })
                    {
                        if (Parameters != null && Parameters.Count > 0)
                            foreach (var key in Parameters.Keys) cmd.Parameters.Add(new SqlParameter(key, Parameters[key]));
                        if (EffectedOnly) /* Sproc or Query must accept @UpdateDate parameter as DateTime */
                        {
                            if (cmd.Parameters.Contains("EffectDate")) cmd.Parameters["EffectDate"].Value = EffectDate;
                            else cmd.Parameters.Add(new SqlParameter("EffectDate", EffectDate));
                        }
                        cmd.Notification = null;
                        Data = new DataTable();
                        new SqlDependency(cmd).OnChange += OnChange;
                        if (sqlConn.State == ConnectionState.Closed) sqlConn.Open();
                        Data.Load(cmd.ExecuteReader(CommandBehavior.CloseConnection));
                    }
                    if ((Events == null || Events.Contains(CurrentEvent)))
                    {
                        if (EffectedCyles > 0) EffectDate = DateTime.Now;
                        EffectedCyles++;
                        if (ActionOnData != null) ActionOnData.Invoke(Data);
                    }
                }
                catch (Exception ex)
                {
                    Logger.LogException(ex);
                }
            });
        }
        private void OnChange(object sender, SqlNotificationEventArgs e)
        {
            CurrentEvent = e.Info;
            SqlDependency dependency = sender as SqlDependency;
            dependency.OnChange -= OnChange;
            Start();      
        }
    }
