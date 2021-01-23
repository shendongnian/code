    private void BtnDelete_Click(object sender, EventArgs e)// Sends to ConfirmDeleteEMP Form 
    {                   
        DataTable table = new DataTable();
        string query = "SELECT PayrollNo, (FirstName + ' ' + LastName) AS NAME FROM [Employee]"; 
        string connstring = @"Provider = Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\HoliPlanData.accdb;Persist Security Info=False";
        using (OleDbConnection conn = new OleDbConnection(connstring))
        {                    
            OleDbDataAdapter adapter = new OleDbDataAdapter(query, conn);
            adapter.Fill(table);                                        
        }
         
        int PayrollNumber = 0;
        foreach (DataRow ThisRow in table.Rows)
        {
            if (DropBoxEmp.Text == ThisRow["NAME"])
            {
                PayrollNumber = (int)ThisRow["PayrollNo"];
                break;
            }  
        }
        //the whole loop could also be consolidated to this:
        //PayrollNumber = (int)table.Rows.First(r => r["NAME"] == DropBoxEmp.Text)["PayrollNo"];
        ConfirmDeleteEMP form = new ConfirmDeleteEMP();
        form.PassValueName = DropBoxEmp.Text;
        form.PassSelectedPayroll = PayrollNumber ;               
        form.Tag = this;
        form.Show(this);
        Hide();
    }
