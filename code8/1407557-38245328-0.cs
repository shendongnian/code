    protected void btn1_Click(object sender, EventArgs e)
    {
        using (SqlCommand cmd = new SqlCommand())
        {
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "AddUpdateCustomer";
            cmd.Parameters.AddWithValue("@FirstName", TextBox1.Text);
            cmd.Parameters.AddWithValue("@LastName", TextBox2.Text);
            cmd.Parameters.AddWithValue("@MiddleName", TextBox3.Text);
            cmd.Parameters.AddWithValue("@Gender", TextBox4.Text);
            GridView1.DataSource = this.GetData(cmd);
            GridView1.DataBind();
        }
    }
