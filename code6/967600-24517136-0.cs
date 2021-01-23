    conn1.Open();
    string query = "select feedurl from [dbo].[feeds]";
    DataSet DS = new DataSet();
    SqlDataAdapter adapt = new SqlDataAdapter(query,conn1);
    adapt.Fill(DS);
    if (DS != null)
    {
         if (DS.Tables[0].rows.Count > 0 )
        {
            foreach(DataRow DR in DS.Tables[0].Rows)
            {
                string temp = DR['columnname'];
            }
        }
    {
    
