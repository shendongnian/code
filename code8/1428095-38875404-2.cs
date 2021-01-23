    private void btnLogin_Click(object sender, EventArgs e)
    {
       try
       {
           if(txtLogin.Text!="" && txtPassword.Text!="")
           {
              Entities2 db = new Entities2();
              foreach (var usert in db.Teachers)
              {
                 if (usert.TID == Convert.ToInt32(txtLogin.Text) &&  usert.Password == txtPassword.Text)
                {
                    Teach teacher = new Teach();
                    teacher.ShowDialog();
                }
                else if (usert.TID != Convert.ToInt32(txtLogin.Text) && usert.Password != txtPassword.Text)
                {
                    MessageBox.Show("Please Enter a Valid Username and/or Password");
                }
            }
          else
          {
             if(txtLogin.Text=="")
             {
                MessageBox.Show("Please Enter a Username");
             }
             else if(txtPassword.Text=="") 
             {
                MessageBox.Show("Please Enter a  Password");
             }
          }
        }
        Catch(Exception ex)
        {
           MessageBox.Show("Please Enter a  Valid Username and/or Password");
        }
    }
    
