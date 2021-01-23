    public string conString = @"Data Source=(LocalDB)\v11.0;
     AttachDbFilename=c:\users\user\documents\visual studio 2012\Projects\WindowsFormsApplication1\WindowsFormsApplication1\Database1.mdf;
     Integrated Security=True";
    private void button1_Click(object sender, EventArgs e)
    {
        try
        {
            String name = txtName.Text;
            String add = txtAdd.Text;
            String tel = txtTel.Text;
            String email = txtEmail.Text;
            String SqlQuery = @"insert into Table 
                                values(@name,@add,@tel,@mail";
            using(SqlConnection con = new SqlConnection(conString))
            using(SqlCommand cmnd = new SqlCommand(SqlQuery, con))
            {
                 con.Open();
                 cmnd.Parameters.Add("@name", SqlDbType.NVarChar).Value = name;
                 cmnd.Parameters.Add("@add", SqlDbType.NVarChar).Value = add;
                 cmnd.Parameters.Add("@tel", SqlDbType.NVarChar).Value = tel;
                 cmnd.Parameters.Add("@email", SqlDbType.NVarChar).Value = email;
                 cmnd.ExecuteNonQuery();
             }
         }
         catch(Exception ex)
         {
              MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
         }
    }
