    if (!IsPostBack)
    {
        string sFilePath = Server.MapPath("Database3.accdb");
        OleDbConnection Conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + sFilePath + ";Persist Security Info=False;");
        using (Conn)
        {
            Conn.Open();
            OleDbCommand myCommand = new OleDbCommand("SELECT COUNT(*) FROM colaborador WHERE username=@username", Conn);
            myCommand.Parameters.Add("?", OleDbType.VarChar).Value = HttpContext.Current.User.Identity.Name;
            int totalRegistos = (int)myCommand.ExecuteScalar();
            if (totalRegistos > 0)
            {
                    // Já registado
                    lblInfo0.Text = "O username já existe na base de dados";
                    empresa.Enabled = false;
                    empresa2.Enabled = false;
                    telemovel.Enabled = false;
                    cmdSave.Visible = false;
            }
        }
    }
