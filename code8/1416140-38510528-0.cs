    public void SQLInfo(string column)
            {
      string query = string.Format("select distinct {0} from [dbo].[ServerAttributes]", column);
      SqlCommand com = new SqlCommand(query);
      SqlDataReader reader = com.ExecuteReader();
