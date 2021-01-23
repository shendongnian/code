    string cmdText = @"insert into myTable
             (OFFICE_CODE,DUMP_NAME,DUMP_STATUS,SYSTEM,CHECK_DATE)
             values(null,:keyw,'0','abc',sysdate)";
    using(OracleConnection conn = new OracleConnection(oradb))
    using(OracleCommand cmd = new OracleCommand(cmdText, conn))
    {
        conn.Open();
        //using(OracleTransaction trans = conn.BeginTransaction())
        //{
        cmd.Parameters.AddWithValue(":keyw",keyword);
        cmd.ExecuteNonQuery();
        // trans.Commit();
        //}
    }
