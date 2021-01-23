    if(txtLogin.Text!="")
       {
          Entities2 db = new Entities2();
          Teacher Tobj=db.Teachers.where(x=>x.TID==Convert.ToInt32(txtLogin.Text) && x.Password==txtPassword.Text).SingleOrDefault();
            if (Tobj!=null)
            {
                Teach teacher = new Teach();
                teacher.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please Enter a Valid Username and/or Password");
            }
       }
       
