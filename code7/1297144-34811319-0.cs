    OleDbCommand cmd = new OleDbCommand(
        "insert into student(fname,fmarks,fboard)values(@fname,@fmarks,@fboard);",
        con
        );
    
    OleDbParameter parmName = cmd.CreateParameter();
    parmName.ParameterName = "@fname";
    parmName.OleDbType = OleDbType.VarChar;
    parmName.Value = txtname.Text;
    cmd.Parameters.Add(parmName);
    
    OleDbParameter parmMarks = cmd.CreateParameter();
    parmMarks.ParameterName = "@fmarks";
    parmMarks.OleDbType = OleDbType.VarChar;
    parmMarks.Value = txtmarks.Text;
    cmd.Parameters.Add(parmMarks);
    
    OleDbParameter parmBoard = cmd.CreateParameter();
    parmBoard.ParameterName = "@fboard";
    parmBoard.OleDbType = OleDbType.VarChar;
    parmBoard.Value = ddlbrd.SelectedItem.ToString();
    cmd.Parameters.Add(parmBoard);
