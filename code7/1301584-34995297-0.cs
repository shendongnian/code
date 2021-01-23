    OracleDataReader dataReader = mDataAccess.SelectSqlRows ( oracleConnection, oracleCommand, sqlCommand, parameters );
    
            while ( dataReader.Read ( ) )
            {
                    groupEntityFacilityRptList.Add ( ReadRecord ( dataReader ) );
            }
