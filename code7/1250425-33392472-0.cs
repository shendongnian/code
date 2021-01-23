        String strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Persist Security Info=False;Data Source='c:\\temp\\Database11.mdb'";
        protected void Page_Load(object sender, EventArgs e)
        {
            OleDbConnection Conn = new OleDbConnection(strConn);
            Label1.Visible = false;
            OleDbCommand com = new OleDbCommand("Select [username],[class],[section],[address] from registration", Conn);
            DataSet ds = new DataSet();
            OleDbDataAdapter da = new OleDbDataAdapter(com);
            da.Fill(ds);
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }
        protected void btnsub_Click(object sender, EventArgs e)
        {
            OleDbConnection Conn = new OleDbConnection(strConn);
            OleDbCommand com = new OleDbCommand("Insert into registration([username],[class],[section],[address])values(@username,@class,@section,@address)", Conn);
            com.Parameters.AddWithValue("@username", Textusername.Text.Trim());
            com.Parameters.AddWithValue("@class", Textclass.Text.Trim());
            com.Parameters.AddWithValue("@section", Textsection.Text.Trim());
            com.Parameters.AddWithValue("@address", Textaddress.Text.Trim());
            Conn.Open();
            com.ExecuteNonQuery();
            Conn.Close();
            Label1.Visible = true;
            Label1.Text = "Records are Submmited Successfully";
        }
    }
