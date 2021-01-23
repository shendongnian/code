    private void GetData(string selectCommand, Label label)
    {
        //open the connection
        OracleConnection conn = new OracleConnection(connectString);
        conn.Open();
        //define the command
        selectCommand = selectCommand.Replace(Environment.NewLine, " ");
        OracleDataAdapter dataAdapter = new OracleDataAdapter(selectCommand, conn);
        OracleCommandBuilder commandBuilder = new OracleCommandBuilder(dataAdapter);
        //run the command
        DataTable table = new DataTable();
        table.Locale = System.Globalization.CultureInfo.InvariantCulture;
        dataAdapter.Fill(table);
        //close the connection
        conn.Close();
        Invoke(new Action(() => RenderData(label, table.Rows[0][0].ToString())));
        
    }
