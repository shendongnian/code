        private void btnEnterAFp1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\AdventureWorks2014.mdf;Integrated Security=True;Connect Timeout=30");
            decimal AF2;
            decimal AF11;
            decimal ResultAF;
            if (string.IsNullOrWhiteSpace(txtp1AF.Text))
            {
                MessageBox.Show("Please Enter fee", "Oops", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (dataGridViewAFp1.Rows[0].Cells[9].Value != null)
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    decimal.TryParse(dataGridViewAFp1.Rows[0].Cells[9].Value.ToString(), out AF11);
                    AF2 = Convert.ToDecimal(txtp1AF.Text);
                    ResultAF = AF11 + AF2;
                    String updatedAF = Convert.ToString(ResultAF);
                    cmd.CommandText = @"Update Production.Product set ListPrice=@af where Name = 'Adjustable Race' OR Name = 'Bearing Ball'";
                    cmd.Parameters.AddWithValue("@af", updatedAF);
                    int n = cmd.ExecuteNonQuery();
                    DataTable dt = new DataTable();
                    SqlDataAdapter adap = new SqlDataAdapter("select * from Production.Product", conn);
                    adap.Fill(dt);
                    dataGridViewAFp1.DataSource = dt;
                    conn.Close();
                    MessageBox.Show("Record Updated Successfully ");
                    txtp1AF.Text = " ";
                }
            }
        }
