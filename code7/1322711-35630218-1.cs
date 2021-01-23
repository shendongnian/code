    private void cbbEmployees_SelectedIndexChanged(object sender, EventArgs e)
        {
            int PayrollNo = 0;
            int AnnualHolidayEntitlemet = 0;
            int DaysTakenToDate = 0;
    
            string Query = "SELECT TOP(1) PayrollNo, AnnualHolidayEntitlement, DaysTakenToDate FROM [Employee] WHERE FirstName +  ' ' + LastName = ?";
            string ConnString = @"Provider = Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\HoliPlanData.accdb;Persist Security Info=False";
    
            using (OleDbConnection conn = new OleDbConnection(ConnString))
            using (OleDbCommand GetAllcmd = new OleDbCommand(Query, conn))
            {
    
                conn.Open();
                GetAllcmd.Parameters.Add("?", OleDbType.VarChar).Value = cbbEmployees.Text;
                GetAllcmd.Parameters.Add("@PayrollNo", OleDbType.VarChar).Value = PayrollNo;               
                GetAllcmd.Parameters.Add("@AnnualHolidayEntitlement", OleDbType.VarChar).Value = AnnualHolidayEntitlemet;
                GetAllcmd.Parameters.Add("@DaysTakenToDate", OleDbType.VarChar).Value = DaysTakenToDate;
                //GetAllcmd.ExecuteScalar(); use GetAllcmd.ExecuteReader() instead
                OleDbDataReader oleDR;
    					oleDR = GetAllcmd.ExecuteReader();
    					if (oleDR.HasRows)
    					{
    						 txtPayrollNo.Text = oleDR["PayrollNo"].ToString();
                             txtAHE.Text = oleDR["AnnualHolidayEntitlemet"].ToString();
                             txtDTTD.Text = oleDR["DaysTakenToDate"].ToString();
                             txtDaysRemaining.Text = (oleDR["AnnualHolidayEntitlemet"] - oleDR["DaysTakenToDate"]).ToString();
    
    					}
    
               
            }
        }
