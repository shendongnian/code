    string sql = "SELECT empSalary from employee where salary = @salary";
    using (SqlConnection connection = new SqlConnection(/* connection info */))
    {
        using (SqlCommand command = new SqlCommand(sql, connection))
        {
            var salaryParam = new SqlParameter("salary", SqlDbType.Money);
            salaryParam.Value = txtMoney.Text;
    
            command.Parameters.Add(salaryParam);
    
            var results = command.ExecuteReader();
        }
    }
