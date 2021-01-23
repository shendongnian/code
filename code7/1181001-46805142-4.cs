    var cmd = new SqlCommand("YourSPWithDataTable", db.Database.Connection as SqlConnection,                                   
                     db.Database.CurrentTransaction.UnderlyingTransaction as SqlTransaction);
    cmd.CommandType = CommandType.StoredProcedure;
    DataTable dt = new DataTable();
    dt.Columns.Add("Name");
    dt.Columns.Add("Val");
    dt.Rows.Add("id_Person", 1);
    dt.Rows.Add("id_Dep", 1);
    cmd.Parameters.Add(new SqlParameter("@AdditionalParams", dt));
    cmd.ExecuteNonQuery();
