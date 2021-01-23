    OleDbCommand comm = new OleDbCommand();
    comm.CommandText = SqlStr;
    comm.Connection = c;
    comm.ExecuteNonQuery();
    c.Close();
}
    catch  (Exception e)
    {
