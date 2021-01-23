        private void btnSave_Click(object sender, EventArgs e)
        {
            AddNames(txtFirstname.Text, txtLastName.Text);
            txtFirstName.Clear();
            txtLastName.Clear();
        }
        public void AddNames(string strFirstName, string strLastName)
        {
            String connString = @"Data Source=ERNIE\SQLEXPRESS;Initial Catalog=LeatherDress;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            using(SqlConnection oCON = new SqlConnection(connString))
           {
            SqlCommand oCMD = new SqlCommand("usp_BasqueNames_Insert",oCon);
            oCMD.CommandType = CommandType.StoredProcedure;
            oCMD.Parameters.Add("@First", SqlDbType.Nchar).Value = strFirstName;
            oCMD.Parameters.Add("@Last", SqlDbType.Nchar).Value = strLastName;
            oCON.open();
            oCMD.ExecuteNonQuery();
            oCON.close();
            }
        }
