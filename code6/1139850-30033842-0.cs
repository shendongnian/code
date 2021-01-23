    string query1,
        result;
    
    query1 = "SELECT printerPath FROM Printers WHERE printerFloor = '?' AND printerNumber = ?";
    
    using (OleDbConnection conn = new OleDbConnection(myDataConnection)) {
        OleDbCommand cmd = new OleDbCommand(query1, conn);
        cmd.Parameters.AddWithValue("PrinterFloor", comboBoxFloor.SelectedItem.ToString());
        cmd.Parameters.AddWithValue("PrinterNum", textBoxPrinterNumber.Text.ToString());
        conn.Open();
        result = cmd.ExecuteScalar();
    }
