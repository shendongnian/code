    private void button2_Click(object sender, EventArgs e)
    {
        string cmdText = @"select * From üyeler 
                           where kullaniciadi=@account 
                             and kullanicisifre=@pass";
        using(OleDbConnection bağlanti = new OleDbConnection(.......))
        using(OleDbCommand komut = new OleDbCommand(cmdText, bağlanti))
        {
            bağlanti.Open();//connection open
            komut.Parameters.Add("@account", OleDbType.VarWChar).Value = textBox1.Text;
            komut.Parameters.Add("@pass", OleDbType.VarWChar).Value = textBox2.Text;
            using(OleDbDataReader okuyucu = komut.ExecuteReader())
            {
                // Now with the WHERE clause if there are rows you have the login
                if(okuyucu.HasRows)
                {
                    MessageBox.Show("tebrikler giriş başarılı");//cong sign in sucseed
                    Form2 frm = new Form2();//going new form
                    frm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Bu kullanıcı adı şifresi yanlıştır");
                }
            }               
        }
    }
