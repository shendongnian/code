               private void button1_Click(object sender, EventArgs e)
        {
        SqlDataAdapter adap;
        DataSet ds;
            
            try
            {
                String myConnection = "data source = KEGA\\SQLEXPRESS; database = KEGA; integrated security=SSPI";
                SqlConnection con = new SqlConnection(myConnection);
                con.Open();
                adap = new SqlDataAdapter("select Eid as 'Employee Id', name as 'First Name', surname as 'Last Name', age as 'Age', gender as 'Gender', phone_number as 'Phone Number', bank as 'Bank', acct_name as 'Account Name', acct_number as 'Account Number' from Clients", con);
                ds = new System.Data.DataSet();
                adap.Fill(ds, "Clients");
                Clients_view.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
`
