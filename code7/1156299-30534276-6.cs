    OleDbParameter parameter;
    // The n-th generic placeholder in the sql string will be set to the n-th registered Parameter Value.
    // '12' represents the data size, adjustment may be needed ( can possibly be dropped altogether ) 
    parameter = command.Parameters.Add("@InputParm", OleDbType.VarChar, 12);
    parameter.Value = comboBox1.Text;
    parameter = command.Parameters.Add("@InputParm", OleDbType.VarChar, 12);
    parameter.Value = label15.Text;
    parameter = command.Parameters.Add("@InputParm", OleDbType.VarChar, 12);
    parameter.Value = comboBox2.Text;
    parameter = command.Parameters.Add("@InputParm", OleDbType.VarChar, 12);
    parameter.Value = label16.Text;
    parameter = command.Parameters.Add("@InputParm", OleDbType.VarChar, 12);
    parameter.Value = comboBox3.Text;
    parameter = command.Parameters.Add("@InputParm", OleDbType.VarChar, 12);
    parameter.Value = label17.Text;
    parameter = command.Parameters.Add("@InputParm", OleDbType.VarChar, 12);
    parameter.Value = comboBox1.Text;
    parameter = command.Parameters.Add("@InputParm", OleDbType.VarChar, 12);
    parameter.Value = comboBox2.Text;
    parameter = command.Parameters.Add("@InputParm", OleDbType.VarChar, 12);
    parameter.Value = comboBox3.Text;
    string query1 =
          "UPDATE Points SET PNTS = "
        + "SWITCH ("
            + "  EmpName = ?, ?"
            + "  EmpName = ?, ?"
            + "  EmpName = ?, ?"
            + ", true, ''"
        + ")"
        + " WHERE EmpName in (?, ?, ?)"
    ;
