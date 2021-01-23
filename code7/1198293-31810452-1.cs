    ... rest of previous code BEFORE the OdbcCommand
    ... and ensure clean values for your colors as others have noted.
    using (OdbcCommand cmd = new OdbcCommand(sql, cn))
    {
       // Just to add the parameter "place-holder" for your query
       cmd.Parameters.AddWithValue("param1", "");
       // DataTable ONCE to receive all the colors being queried
       DataTable tblAllColors = new DataTable();
    
       // build the adapter ONCE no matter how many colors you will be querying
       OdbcDataAdapter adapter = new OdbcDataAdapter(cmd);
    
       // so for this loop, you are just getting the colors one at a time.
       foreach( string s in colorList )
       {
          // next color you are trying to get... just overwrite the 
          // single parameter with the new color.
          adapter.SelectCommand.Parameters[0].Value = s;
          adapter.Fill(tblAllColors);
       }
    
       // you would otherwise have to build your query dynamically and keep 
       // adding parameter-placeholders "?" for each color in a comma list 
       // as you were attempting... which would be a slightly different query.
    }
    
    dsColors.Tables.Add( tblAllColors );
