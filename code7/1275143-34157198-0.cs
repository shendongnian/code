    private bool CheckandBlockEmp(int empID)
    {
        string commText = @"select COUNT(EmpID) 
                            from ItemTicketSection 
                            where [Type]='Permanent' 
                                  AND EmpID=@id";
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
