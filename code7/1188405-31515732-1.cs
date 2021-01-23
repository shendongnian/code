    protected void cmdSave_Click(object sender, EventArgs e)
        {
            string sFilePath = Server.MapPath("Database3.accdb");
            OleDbConnection Conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + sFilePath + ";Persist Security Info=False;");
            string insertCmd = "IF NOT EXISTS(Select * FROM colaborador where username=@username)"+
                                   "INSERT INTO colaborador(Empresa,Empresa2,Telemovel,username) VALUES (@Empresa,@Empresa2,@Telemovel,@username)"+
                                "ELSE"+ 
                                  "Update colaborador SET Empresa=@Empresa,Empresa2=@Empresa2,Telemovel=@Telemovel where username=@username"; 
            using (Conn)     
            {
                Conn.Open();
                OleDbCommand myCommand = new OleDbCommand(insertCmd, Conn);
                myCommand.Parameters.AddWithValue("@Empresa", empresa.Text);
                myCommand.Parameters.AddWithValue("@Empresa2", empresa2.Text);
                myCommand.Parameters.AddWithValue("@Telemovel", telemovel.Text);
                myCommand.Parameters.AddWithValue("@username", HttpContext.Current.User.Identity.Name);            
                Response.Write(" ");
                myCommand.ExecuteNonQuery(); 
                lblInfo.Text = "Dados guardados!";
                lblInfo.ForeColor = System.Drawing.Color.Green;
            }
        }
