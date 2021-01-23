    protected void Page_Load(object sender, EventArgs e)
    {
        username.Text = "[" + HttpContext.Current.User.Identity.Name + "]"; 
    
        if (!IsPostBack)
        {
            string sFilePath = Server.MapPath("Database3.accdb");
            OleDbConnection Conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + sFilePath + ";Persist Security Info=False;");
            using (Conn)
            {
                Conn.Open();
                OleDbCommand myCommand = new OleDbCommand("SELECT COUNT(*) FROM colaborador WHERE username=@username", Conn);
                myCommand.Parameters.Add("?", OleDbType.VarChar).Value = HttpContext.Current.User.Identity.Name;
                SqlDataReader reader = myCommand.ExecuteReader();
                
                if (reader.HasRows)
                {
                        // Já registado
                        Label1.Text = "The user already answered before.";
                        business.Enabled = false;
                        business2.Enabled = false;
                        mobile.Enabled = false;
                        mobile.Text = ""; //if this is a textbox
                        Button1.Visible = false;
                }
            }
        }
