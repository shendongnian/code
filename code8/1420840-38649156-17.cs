    void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            using (SqlConnection conn = new SqlConnection("Data Source=(local); Integrated Security = True; Initial Catalog=TestMP"))
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM Clients ORDER BY ClientID ASC", conn))
            {
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                dataAdapter.Fill(dt);
                int halfCount = dt.Rows.Count / 2;
                dtTopHalf = dt.AsEnumerable().Select(x => x).Take(halfCount).CopyToDataTable();
                dtBottomHalf = dt.AsEnumerable().Select(x => x).Skip(halfCount).CopyToDataTable();
            }
            // Each value in the Repeater indicates if it is the top half or not
            repeater1.DataSource = new List<bool>() { true, false };
            repeater1.DataBind();
        }
    }
