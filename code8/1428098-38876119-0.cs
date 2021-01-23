    private void btnLogin_Click(object sender, EventArgs e)
    {
        int userId;
    
        if (int.TryParse(txtLogin.Text, out userId))
        {
           Entities2 db = new Entities2();
           foreach (var usert in db.Teachers)
           {
               if (usert.TID == userId && usert.Password == txtPassword.Text)
               {
                  Teach teacher = new Teach();
                  teacher.ShowDialog();
               }
               else
               {
                  MessageBox.Show("Please Enter a Valid Username and/or Password");
               }
           }
        }
        else
        {
             MessageBox.Show("Please Enter a Valid User ID");
    
        }
    }
