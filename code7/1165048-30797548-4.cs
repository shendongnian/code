    private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string C = ConfigurationManager.ConnectionStrings["D"].ConnectionString;
                using (var con = new SqlConnection(C))
                using (var cmd = new SqlCommand())
    
                {
                    SqlDataReader myReader;
                    cmd.CommandText = ("[dbo].[spInfo]");
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Periode2", cbPeriode2.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@Periode1", cbPeriode1.SelectedValue.ToString());
                    con.Open();
                    myReader = cmd.ExecuteReader();
                    DataTable datatable = new DataTable();    
                   if(myReader.HasRows)
                    {
                        datatable.Load(myReader);
                        //datagridview1.DataSource = datatable;
                    }
                    con.Close();
                    ShowForm2(datatable);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
    }
    public void ShowForm2(DataTable yourData)
    {
        DataTable Data = yourData;
        Form2 frm = new Form2(Data);
        frm.Show();
    }   
    
