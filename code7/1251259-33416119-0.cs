    private void tableListBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        private DataTable dataTable;
        string constring = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\IncomerDefault.mdf;Integrated Security=True;Connect Timeout=30";
        string Query = "SELECT * FROM [Table] WHERE Default_Name = '" + tableListBox.SelectedValue + "'";
        SqlConnection con = new SqlConnection(constring);
        SqlCommand cmd = new SqlCommand(Query, con);
        try
        {
             con.Open();
            
             SqlDataAdapter da = new SqlDataAdapter(cmd);
             da.Fill(dataTable);
             foreach(DataRow row in dataTable.Rows)
             {
                  textBox1.Text = row[2].ToString();
                  comboBox1.Text = row[3].ToString();
                  comboBox3.Text = row[4].ToString();
                  textBox2.Text = row[6].ToString();
                  comboBox2.Text = row[7].ToString();
                  comboBox4.Text = row[8].ToString();
            }
            da.Dispose();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
        con.Close();
     }
