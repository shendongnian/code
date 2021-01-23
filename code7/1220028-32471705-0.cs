       public DataSet Get_CurrentTask(Employee emp)
    {
        if (inst.isConnected == true)
        {
            string query = "SELECT employees.empl_id, employees.emp_name FROM employees  LEFT  JOIN TASK_SUM   On employees.empl_id= TASK_SUM.emp_ID";  
            Database inst.Command = new System.Data.OracleClient.OracleCommand(query, inst.getConnection());
            inst.Command.CommandType = CommandType.Text;
            OracleDataAdapter da= new OracleDataAdapter(inst.Command);
            OracleCommandBuilder cb = new OracleCommandBuilder(da);
            OracleDataReader reader = inst.Command.ExecuteReader();
            DataSet ds = new DataSet();
            da.Fill(ds);
        }
        return ds;
    }
