        /// <summary>
        /// Returns a SQLClient Connection String from an ODBC string 
        /// </summary>
        private string ODBCToToSqlClient(string ODBCConnectionString)
        {           
            OdbcConnectionStringBuilder builder = new OdbcConnectionStringBuilder(ODBCConnectionString);                        
            if (builder.ContainsKey("Uid"))            
            {
                //Standard Connection
                return string.Format("Server={0};Database={1};User Id={2};Password={3};", builder["Server"], builder["Database"], builder["uid"], builder["pwd"]);
            }
            else 
            {
                //Trusted Connection
                return string.Format("Server={0};Database={1};Trusted_Connection=True;", builder["Server"], builder["Database"]);                
            }
        }
