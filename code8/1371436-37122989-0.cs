    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            Label1.Text = Session["uid"].ToString();
            Label2.Text = Session["crs_id"].ToString();
            ListBox1.Items.Clear();
            SqlDataReader r;
            SqlCommand cmd = new SqlCommand("select lecture_text, lecture_Title,lecture_No   from Lecture where course_ID='" + Convert.ToInt32(Session["crs_id"]) + "'", con);
            con.Open();
            ListBox1.DataSource = cmd.ExecuteReader();
            ListBox1.DataTextField = "lecture_Title";
            ListBox1.DataValueField = "lecture_No";
            ListBox1.DataBind();
            con.Close();        
            ListBox1.Items.Insert(0, new ListItem("--Select Customer--", "0"));
        }
    }
