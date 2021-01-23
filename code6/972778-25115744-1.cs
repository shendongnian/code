    public CaseDataDataContext(DbConnection connection)
                : base(connection, true) 
            {
                _isSqlServer = false; 
            }
