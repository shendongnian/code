    public List<GraphModel> countRequestCreatedByTypeDefaulPage(string[] employeesIds)
    {
        OracleTransaction trans = conn.BeginTransaction(IsolationLevel.ReadCommitted);
        OracleCommand cmd = new OracleCommand("insert into employee_list values (:EMPLOYEE)",
            conn);
        cmd.Transaction = trans;
        cmd.Parameters.Add(new OracleParameter("EMPLOYEE", OracleDbType.Varchar2));
        cmd.Parameters[0].Value = employeesIds;
        cmd.ArrayBindCount = employeesIds.Length;
        cmd.ExecuteNonQuery();
        String sql = "";  // code from above goes here
        cmd = new OracleCommand(sql, conn);
        cmd.Transaction = trans;
        DataTable dataTable = null;
        try
        {
            dataTable = Data_base_Access.executeSQL(cmd,
                ConfigurationManager.ConnectionStrings["stage"].ToString());
            return (GraphModel.convertToList(dataTable));
        }
        catch (Exception ex)
        {
            Log.writeError("Request DAO", ex);
            throw new DataAccessException("There was an error counting the open requests");
        }
        finally
        {
            trans.Rollback();
        }
        return dataTable;
    }
