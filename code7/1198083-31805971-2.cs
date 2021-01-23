    StringBuilder query = New StringBuilder();
    //Name
    if (this.nameTextBox2.Text.Length > 0)
    {
        query.AppendLine(", [Name]=@Name");
        command.Parameters.Add("@Name", OleDbType.VarChar).Value = this.nameTextBox2.Text;
    }
    //Email
    if (this.emailTextBox2.Text.Length > 0)
    {
        query.AppendLine(", Email=@Email");
        command.Parameters.Add("@Email", OleDbType.VarChar).Value = this.emailTextBox2.Text;
    }
    // ... 
    // And other control in same way
    // Then check if something updated
    if(query.Length == 0)
        Return;
    // Remove first "," character if updates exists
    query.Remove(0,1);
    query.Insert("UPDATE Customer SET ");
    query.AppendLine("WHERE TransactionNo=@TranNo");
    OleDbParameter tranno = New OleDbParameter("@TranNo", OleDbType.Integer);
    tranno.Value = Int32.Parse(this.idTextBox.Text);
    command.Parameters.Add(tranno);
    // Run query
    command.CommandText = query.ToString();
    command.ExecuteNonQuery();
