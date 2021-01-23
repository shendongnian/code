    string fname = textBox1.Text;
    string lname = textBox2.Text;
    
    using(OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Zied\Documents\Visual Studio 2010\Projects\testerMSAcceess\testerMSAcceess\bin\Debug\zimed.mdb"))
    using(OleDbCommand cmd = new OleDbCommand("INSERT INTO [user] ([nom],[prenom]) VALUES (@fname,@lname)", conn))
    {
       try
       {
          conn.Open();
          cmd.Parameters.AddWithValue("@fname", fname);
          cmd.Parameters.AddWithValue("@lname", lname);
          cmd.ExecuteNonQuery();
          MessageBox.Show("ajout ok ");
       }
       catch (Exception ex) { MessageBox.Show("Erreur" + ex.Source); }
       finally { if (conn.State == ConnectionState.Open) { conn.Close(); } }
    }
