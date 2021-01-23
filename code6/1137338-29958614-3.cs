    class MyClass
    {
        OleDbConnection _rootConn;
        string _connStr;
    
        public MyClass()
        {
            _connStr = string cisconn = ConfigurationManager.ConnectionStrings["CTaC_Information_System.Properties.Settings.CIS_beConn"].ConnectionString;
            _rootConn = new OleDbConnection(_connStr);
        }
    
        public void DoSomeDatabaseOp()
        {
            //Use _rootConn here
        }
    }
