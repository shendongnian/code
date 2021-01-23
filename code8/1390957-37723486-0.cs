    protected void btn_update_Click(object sender, EventArgs e)
    {
        using(var con = new SqlConnection(conn))
        {        
            con.Open();
            var commandTest = "update UserData set Password=@Password where UserName=@Username";
            using(var com = new SqlCommand(str, con))
            {
                com.Parameters.AddWithValue("@Username", txtUser.Text);
                com.Parameters.AddWithValue("@Password", BusinessLayer.ShoppingCart.CreateSHAHash(txtPW.Text));
                if(com.ExecuteNonQuery() == 1)
                {
                    Label1.Visible = true;
                    Label1.Text = "Password changed Successfully!" ;            
                }
            }
        }
    }
