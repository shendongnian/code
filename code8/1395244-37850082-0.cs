    public boolean insertToTable (SQLiteConnection sql, string TableName, string Date, string Receipt, string Particulars, string Description, string Category, double amount)
    {
        SQLiteCommand command = new SQLiteCommand(sql);
        if (sql == null)
            return false;
        String statement = 
            "INSERT INTO " + TableName + " (Date, Receipt,Particulars,Description,Category,Amount) " +
            "VALUES (@date, @rec,@part,@desc,@cat,@amt)";
    
        command.Parameters.AddWithValue("@date",Date);
        command.Parameters.AddWithValue("@rec", Receipt);
        command.Parameters.AddWithValue("@part", Particulars);
        command.Parameters.AddWithValue("@desc", Description);
        command.Parameters.AddWithValue("@cat", Category);
        command.Parameters.AddWithValue("@amt", amount);
        command.Prepare();
        int x = command.ExecuteNonQuery(); // change to command.ExecuteNonQuery() depending what you need
        return true;
    }
