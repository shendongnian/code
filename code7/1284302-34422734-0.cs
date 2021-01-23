    public DataTable checkAccident(string LicenseNumber, string PhysicalStatus)
    {
        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB; Integrated Security=True; Initial Catalog=tprojectDB;");
        string sql = "select DeathNumber,ReportNumber,Date from tblAccident where LicenseNumber=@LicenseNumber and PhysicalStatus=@PhysicalStatus";
        SqlCommand cmd = new SqlCommand(sql, con);
        cmd.Parameters.AddWithValue("@LicenseNumber", LicenseNumber);
        cmd.Parameters.AddWithValue("@PhysicalStatus", PhysicalStatus);
    
        SqlDataAdapter da = new SqlDataAdapter(cmd);
    
        DataTable dl = new DataTable();
        da.Fill(dl);
        return dl;
    }    
    
    private void button10_Click_1(object sender, EventArgs e)
    {
        DataTable dan = pac.checkAccident(txtlicense.Text, cboaccidentype.Text);
        if (dan.Rows.Count > 0)
        {
            dataGridView2.DataSource = dan;
        }
        else
        {
            MessageBox.Show("No Record Found");
        }
    }
