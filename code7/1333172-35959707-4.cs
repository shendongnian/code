    using (var conn = DatabaseConnection.OpenConnection())
    using (var SqlCom = new SqlCommand("UpdateCasesIsConveyed", conn))
    {
        // setup and execute the SP, can return from in here
    }
