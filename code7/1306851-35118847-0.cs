    DataTable oracleTbl = GetOracleData();
    DataTable sqlTbl = GetSqlData();
    
    var results = from oracleTbl in dt1.AsEnumerable()
                     join sqlTbl in dt2.AsEnumerable() on (Guid)sqlTbl ["ID"] equals (int)oracleTbl["ID"]
                     select new
                     {
                         //Select data you need
                     };
