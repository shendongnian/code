    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            con.Open();
            string sel = "select Room_Type , Picture from room_details";
            SqlCommand cmd = new SqlCommand(sel, con);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            DataList1.DataSource = dt;
            DataList1.DataBind();
            con.Close();
        }
    }
