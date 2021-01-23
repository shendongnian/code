     List<OracleParameter> prms = new List<OracleParameter>();
     var strQuery = @"SELECT * from STCD_PRIO_CATEGORY 
                      where STPR_STUDY.STD_REF IN(";
     // Create a list of parameters and prepare the placeholders for the IN     
     StringBuilder sb = new StringBuilder(strQuery);
     for(int x = 0; x < inconditions.Length; x++)
     {
        // Placeholder
        sb.Append(":p" + x + ",");
        // Parameter
        OracleParameter p = new OracleParameter(":p" + x, OracleType.Int32);
        p.Value = inconditions[x];
        prms.Add(p);
     }
     // Remove the last comma
     if(sb.Length > 0) sb.Length--;
     // Prepare the correct IN clause
     strQuery = strQuery + sb.ToString() + ")";
     using (OracleCommand selectCommand = new OracleCommand(strQuery, dbconn))
     {
         // Add the whole set of parameters
         selectCommand.Parameters.AddRange(prms.ToArray());
         using (OracleDataAdapter adapter = new OracleDataAdapter(selectCommand))
         {        
             DataTable selectResults = new DataTable();
             adapter.Fill(selectResults);
             .....
