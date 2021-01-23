    var conStr = @"Provider = Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\HoliPlanData.accdb;Persist Security Info=False";
    using(var conn = new OleDbConnection(conStr))
    using(var dbCmd = conn.CreateCommand())
    {
       dbCmd.CommandText = "SELECT count(*) FROM [Employee] where PayrollNo = @PayrollNo";
       dbCmd.Parameters.Add("@PayrollNo", OleDbType.Integer).Value = yourPayrollNo;
    
       conn.Open();
       int count = (int)dbCmd.ExecuteScalar();
       if(count > 0)
       {
          PayrollExists form = new PayrollExists();
          form.Tag = this;
          form.Show(this);
          Hide();
       }
       else
       {
          EmployeeDetails form = new EmployeeDetails();
          form.PassValueFirstName = txtFirstName.Text;
          form.PassValueLastName = txtLastName.Text;
          form.PassValuePayrollNo = txtPayrollNo.Text;
          form.Tag = this;
          form.Show(this);
          Hide();
       }      
    }
