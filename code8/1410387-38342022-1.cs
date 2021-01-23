    TO YOUR CODE BEHIND:
    using System.Configuration;
    using Npgsql;
    using System.Data;
    private static DataSet GetTData(ref string msg)
        {
            String Query = Query = @"select column1,column2 from table1";
                String connstr =           ConfigurationManager.ConnectionStrings["npgsql"].ToString();
            NpgsqlConnection cnn = new NpgsqlConnection(connstr);
            NpgsqlDataAdapter adp = new NpgsqlDataAdapter(Query, cnn);
            DataSet ds = new DataSet();
            try
            {
                adp.Fill(ds);
                msg = String.Empty;
                return ds;
            }
            catch (Exception e)
            {
                msg = e.Message;
                return ds;
            }
            finally
            {
                ds.Dispose();
                if (cnn != null)
                {
                    cnn.Close();
                    cnn.Dispose();
                    adp.Dispose();
                }
            }
        }
To use this:
     private void form_Load(object sender, EventArgs e)
    {
         String error = string.empty
     DataSet ds = new Dataset();
     ds= GetTData(ref error);
    if(error!=string.empty )
     {
      MessageBox.Show(error);
      return;
      }
    }
