    void SqlMapper.IDynamicParameters.AddParameters(IDbCommand command, SqlMapper.Identity identity)
    {
    	 // Checks if profiler is used, if it is, then retrieve `InternalCommand` property
         dynamic oracmd = command is OracleCommand ? command : ((ProfiledDbCommand)command).InternalCommand;
         this.AddParameters((OracleCommand)oracmd, identity);
    }
