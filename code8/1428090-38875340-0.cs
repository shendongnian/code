     private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtLogin.Text != "")
               {
                  Entities2 db = new Entities2();
                  foreach (var usert in db.Teachers)
                        {
                          if (usert.TID == Convert.ToInt32(txtLogin.Text) && usert.Password == txtPassword.Text)
                       {
                         Teach teacher = new Teach();
                         teacher.ShowDialog();
                       }
                       else if (usert.TID != Convert.ToInt32(txtLogin.Text) && usert.Password != txtPassword.Text)
                       {
                          MessageBox.Show("Please Enter a Valid Username and/or Password");
                     }
                  }
               }
               else 
               {
               MessageBox.Show("Fill the box w/your Login");
               }
        
        }
