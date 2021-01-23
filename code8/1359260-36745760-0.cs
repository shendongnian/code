     public void getEmployee(int employee_id)
    {
        string cmdQuery = @"SELECT First_Name, Email, Salary INTO :FirstName, :EmailAddress, :CurrentSalary FROM EMPLOYEES WHERE employee_id = :Employee_id";
        trans_r = conn_r.BeginTransaction();
        try
        {
            OracleCommand cmd = new OracleCommand(cmdQuery, conn_u);
            cmd.BindByName = true;
            //WHERE Parameters
            OracleParameter paramDepartment_Id = new OracleParameter(":Employee_id", employee_id);
            paramDepartment_Id.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(paramDepartment_Id);
            //INTO Parameters
            OracleParameter param_Name_out = new OracleParameter(":FirstName", OracleDbType.Varchar2, ParameterDirection.ReturnValue);
            cmd.Parameters.Add(param_Name_out);
            OracleParameter param_Email_out = new OracleParameter(":EmailAddress", OracleDbType.Varchar2, ParameterDirection.ReturnValue);
            cmd.Parameters.Add(param_Email_out);
            OracleParameter param_Salary_out = new OracleParameter(":CurrentSalary", OracleDbType.Int32, ParameterDirection.ReturnValue);
            cmd.Parameters.Add(param_Salary_out);
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            OracleCommandBuilder cb = new OracleCommandBuilder(da);
            cmd.ExecuteReader();
        }
        catch (OracleException ex)
        {
            throw ex;
        }
    }
