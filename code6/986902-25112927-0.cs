    SqlConnection sqlcon = new SqlConnection("server=.;database=DB_TEST;" + 
                                         "trusted_connection=true");
    SqlCommand sqlkmt = new SqlCommand("Select SUM(QUANTITY) from Stock " + 
                                       "where ProductID='" + 
                                        cmbxProductID.SelectedValue + "'",  sqlcon);                       
    sqlcon.Open();
    int result= sqlkmt.ExecuteScalar();
    sqlcon.Close();
    if (result == int.Parse(textBox1.Text))
    {
        MessageBox.Show("Stock in not adeqaute");
    }
