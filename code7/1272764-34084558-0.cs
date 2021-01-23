    public DataTable MyExample(string connectionString)
    {
        DataSet ds = new DataSet();
        using (DALHelper dal = new DALHelper(connectionString))
        {
            try
            {
                dal.OpenDB();
                ParameterInfo[] param = new ParameterInfo[0];
                ds = dal.ExecuteDataSet("StoredProcedure", CommandType.StoredProcedure, param);
            }
            //Here where message goes. if there's an error. So it's up to you.
            catch (Exception er)
            {
                throw er;
            }
            finally
            {
            //Here is, if successful..
            //Do the Code here....
            }
        }
    }
