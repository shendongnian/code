    private void encryptAccounts()
    {
        SimpleAES simpleAES1 = new SimpleAES();
        // iterate over all DGV rows
        for (int r = 0; r < dataGridViewAccounts.Rows.Count; r++)
        {
            string password = dataGridViewAccounts[4, r].Value.ToString();
            dataGridViewAccounts[4, r].Value = simpleAES1.EncryptToString(password);
        }
        
        // OR
        foreach (DataGridViewRow row in dataGridViewAccounts.Rows)
        {
            string password = row.Cells[4].Value.ToString();
            row.Cells[4].Value = simpleAES1.EncryptToString(password);
        }
    }
