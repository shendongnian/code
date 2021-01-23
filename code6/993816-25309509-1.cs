    public void PullData(string sortExp, string sortDir)
    {
        string query = String.Format("{0}{1}", strMainQuery, GenerateWhereClause());
        DataTable taskData = new DataTable();
        connString = ""; //the connection string is here
        
        using (SqlConnection conn = new SqlConnection(connString))
        {
            try
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                // create data adapter
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                // this will query your database and return the result to your datatable
                DataSet myDataSet = new DataSet();
                da.Fill(myDataSet);
                DataView myDataView = new DataView();
                myDataView = myDataSet.Tables[0].DefaultView;
                if (sortExp != string.Empty)
                {
                    myDataView.Sort = string.Format("{0} {1}", sortExp, sortDir);
                }
                yourTasksGV.DataSource = myDataView;
                yourTasksGV.DataBind();
                conn.Close();
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
        }
    }
