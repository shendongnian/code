    DB db = new DB();
    SqlDataReader dr = new SqlDataReader();
    string username = txtUsername.Text;
    string pass = txtPassword.Text;
      if (rdoStu.Checked)
        dr=db.select("Select * from tbl_stu where stuId='" + username + "'and mcode='" + pass +"'");
      else if (rdoTch.Checked)
        dr=db.select("select * from tbl_tch where tchId='" + username + "'and mcode='" + pass+"'");
    if (dr.Read())
    {
      MessageBox.Show("Welcome");
    }
