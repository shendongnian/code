    private void FillCombobox2()
    {
        string S = ConfigurationManager
 
        // TSQL-Statement
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = ("SELECT DISTINCT Monat from tblSales");            
        //SqlDataReader myReader;
        try
        {
            con.Open();
         SqlDataAdapter ad = new SqlDataAdapter(cmd);
         DataTable dt = new DataTable();
                ad.Fill(dt)             
                combobox1.DisplayMember = "Monat";
                combobox1.ValueMember = "Monat";
                combobox1.DataSource = dt;
                combobox1.SelectedIndex = -1;
 
            }
 
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
        finally
        {
            con.Close();
        }
    }
