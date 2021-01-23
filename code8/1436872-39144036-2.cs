    for (int i = 1; i <= NumOfButtons; i++)
    {
        cmd.CommandText = "SELECT username FROM Login where id='" + i.ToString() + "'";
        var Text = cmd.ExecuteScalar();
        if(Text != null) {
            Button btn = new Button();
            {
                //...
            }
        }
    }
        
