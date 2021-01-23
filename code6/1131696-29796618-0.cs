    using(var con = new OracleConnection(constr))
    using(var cmd = con.CreateCommand())
    {
       cmd.CommandText = @"Insert into EMP_DETAIL(EmpId, Name, Age)
                           values (:EmpId, :Name, :Age)";
       cmd.Parameters.Add(new OracleParameter("EmpId", OracleDbType.Varchar2)).Value = txtEmpId;
       cmd.Parameters.Add(new OracleParameter("Name", OracleDbType.Varchar2)).Value = txtName;
       cmd.Parameters.Add(new OracleParameter("Age", OracleDbType.Int16)).Value = int.Parse(txtAge.Text);
       con.Open();
       cmd.ExecuteNonQuery();
    }
