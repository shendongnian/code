    System.Windows.Forms.TextBox txt = new System.Windows.Forms.TextBox();
    OleDbCommand command = new OleDbCommand();
    command.Connection = connection;
    string query = " select * FROM Other ORDER BY Type";
    command.CommandText = query;
    OleDbDataReader reader = command.ExecuteReader();
    txt.Text = "txtpertanyaan"+cLeft;
    this.Controls.Add(txt);
    txt.Top = cLeft *25;
    txt.Left = 100;
    if (reader.HasRows)
    {
        for (int i = 0; i < cLeft ; i++)
        {
            reader.Read();
        }
        txt.Text = reader["Type"].ToString();
        Reader.Read();
    }    
        
    cLeft = cLeft+1;
    return txt;
