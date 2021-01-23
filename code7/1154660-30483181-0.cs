    Boolean doUnion = true;
    String yourExternalCompsedWhere = "1=1";
    String strQuery = String.Format(@"DECLARE @param int -- any type
    --DECLARE anything else
    SET @param = {0}
    SELECT {1} ColumnA, {2} ColumnB FROM TableX WHERE Field3 = @param
    WHERE {3}", param, "Field1", "Field2", yourExternalComposedWhere);
    if (doUnion)
        strQuery += String.Format(@"
    UNION
    SELECT {0}, {1} FROM TableY WHERE Field7 != @param", "Field3", "Field4");
    
    SqlConnection sqlConn = new SqlConnection(strConn);
    sqlConn.Open();
    SqlCommand sqlCmd = new SqlCommand(strQuery, sqlConn);
    SqlDataReader sqlDR = sqlCmd.ExecuteReader();
    while (sqlDR.Read())
    {
    //Do what you need to do
    };
    sqlDr.Close()
