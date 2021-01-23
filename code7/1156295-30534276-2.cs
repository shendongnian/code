    OleDbParameter parameter;
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
          "UPDATE Points SET PNTS = ("
        + "case EmpName when ? then ?
                    + " when ? then ? 
                    + " when ? then ? 
                    + " else ''"
        + " end)"
        + " WHERE EmpName in (?, ?, ?)"
    ;
