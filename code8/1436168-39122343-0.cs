    private void btnUpdate_Click(object sender, EventArgs e)
            {
                if (txtNo.Text == "" || txtName.Text == "" || txtAddress.Text == "")
                {
                    MessageBox.Show("Please Fill TextBox");
                    return;
                }
                SqlCommand CMD = new SqlCommand(UPDATE...
                Connection.Buka.....();
                CMD.ExecuteNonQuery();
                MessageBox.Show(....)
                Connection.Tutu.....();
            }
