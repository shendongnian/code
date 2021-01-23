    private bool CheckandBlockEmp(int empID)
    {
        string commText = @"IF EXISTS (SELECT 1 FROM ItemTicketSection 
                                       WHERE [Type]='Permanent' AND EmpID=@id) 
                                       SELECT 1 ELSE SELECT 0";
        using(SqlConnection conn = new SqlConnection(dbcon.ReturnConnection()))
        using(SqlCommand cmdCheck = new SqlCommand(commText, conn))
        {
            conn.Open();
            cmdCheck.Parameters.Add("@id", SqlDbType.Int).Value = empID;
            var check = cmdCheck.ExecuteScalar();
            if (check != null)
            {
                int num = Convert.ToInt32(check);
                return (num == 0);
            }
        } 
    }
