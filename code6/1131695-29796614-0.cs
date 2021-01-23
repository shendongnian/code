    string str = "Insert into EMP_DETAIL(EmpId, Name, Age) values (:EmpId, :Name, :Age)";
    OracleCommand cmd = new OracleCommand();
    cmd.CommandText = str;  //cmd.CommandText = Text; not sure why did you use Text here
    cmd.Connection = con;
    cmd.Parameters.Add(new OracleParameter("EmpId", OracleDbType.Varchar2)).Value = txtEmpId;
    cmd.Parameters.Add(new OracleParameter("Name", OracleDbType.Varchar2)).Value = txtName;
    cmd.Parameters.Add(new OracleParameter("Age", OracleDbType.Int16)).Value = int.Parse(txtAge.Text);
    cmd.ExecuteNonQuery();
