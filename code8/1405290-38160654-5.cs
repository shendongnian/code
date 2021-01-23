    command.CommandText = "UPDATE Bills SET ([Payer] = @Payer, [Category] = @Category, ...) WHERE Id = @Id";
    command.Parameters.Add("@Payer", OleDbType.VarWChar).Value = bill.Payer;
    command.Parameters.Add("@Category", OleDbType.VarWChar).Value = bill.Category;
    ....
    command.Parameters.Add("@DueDate", OleDbType.Date).Value = bill.DueDate.Date;
    ....
    command.Parameters.Add("@Id", OleDbType.Integer).Value = bill.Id;
