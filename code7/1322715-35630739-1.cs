        private void cbbEmployees_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string Query = "SELECT PayrollNo, AnnualHolidayEntitlement, DaysTakenToDate FROM [Employee] WHERE PayrollNo =" + Convert.ToInt32(cbbEmployees.SelectedValue); 
            
           
            string ConnString = @"Provider = Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\HoliPlanData.accdb;Persist Security Info=False";
            using (OleDbConnection conn = new OleDbConnection(ConnString))
            using (OleDbCommand GetAllcmd = new OleDbCommand(Query, conn))
            {
                DataTable dt = new DataTable();
                conn.Open();
                dt.Load(GetAllcmd.ExecuteReader());
                conn.Close();
                 txtPayrollNo.Text = dt.Rows[0][0].ToString();
                 txtAHE.Text = dt.Rows[0][1].ToString();
                 txtDTTD.Text = dt.Rows[0][2].ToString();
                
            }
        }
