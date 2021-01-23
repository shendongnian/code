    var cmd = new SqlCommand(@"INSERT INTO [Obj CA] ([Rayon],sheetname)
                                   VALUES('sheetname', @rayon"), con);
    for (int i = 2; i < dt.Rows.Count; i++)
    {
          for (int j = 1; j < dt.Columns.Count; j += 3)
          {   
              cmd.Parameters.Clear();           
              cmd.Parameters.AddWithValue("@rayon", dt.Rows[0][j].ToString());
              command.ExecuteNonQuery();
           }
    }
