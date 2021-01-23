    public void button1_Click(object sender, EventArgs e)
        {
            
            using (StreamReader reader = new StreamReader("UserFile.txt"))
            {
               string s;
               s = reader.ReadLine();
               string[] ss = s.Split(':');
               if (txtUser.Text == ss[0])
               {
                 if (txtPass.Text == ss[1])
                 {
                    this.Hide();
                    Properties.Settings.Default.ss = txtUser.Text;
                    Properties.Settings.Default.Save();
                    frmMainMenu mf = new frmMainMenu();
                    mf.Show();
                 }
                 else
                 {
                    MessageBox.Show("Sorry Wrong Password");
                 }
               }  
               else
               {
                 MessageBox.Show("Sorry Wrong Username");
               }
            }
                
       }
