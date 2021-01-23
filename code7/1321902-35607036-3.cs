    private void BtnDelete_Click(object sender, EventArgs e)// Sends to ConfirmDeleteEMP Form 
    {     
        object result;       
        string query = "SELECT PayrollNo FROM [Employee] WHERE FirstName + ' ' + LastName = ?"; 
        string connstring = @"Provider = Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\HoliPlanData.accdb;Persist Security Info=False";
        using (OleDbConnection conn = new OleDbConnection(connstring))
        using (OleDbCommand cmd = new OleDbCommand(query, conn))
        {
            //guessing at type and length here
            cmd.Parameters.Add("?", OleDbType.VarWChar, 50).Value = DropBoxEmp.Text;
            conn.Open();
            result = cmd.ExecuteScalar();                                        
        }
        if (result != null && result != DBNull.Value)
        {
            ConfirmDeleteEMP form = new ConfirmDeleteEMP();
            form.PassValueName = DropBoxEmp.Text;
            form.PassSelectedPayroll = (int)result;
            form.Tag = this;
    
            form.Show(this);
            Hide();
        }                    
    }
