    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        Label2.Text = DropDownList1.SelectedItem.Value;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
         if (!IsPostBack)
         {
              string username = Session["username"].ToString();
              SqlConnection con = new SqlConnection("Data Source=DLINK\\SQLEXPRESS;User ID=sa;Password=logmein;Initial Catalog=AndroidAppDB");
              SqlCommand cmd = new SqlCommand();
              cmd.Connection = con;
              con.Open();
              string query = "select Fence_Name from Fence where Username='" + username + "'";
              SqlCommand command = new SqlCommand(query, con);
             DropDownList1.DataSource = command.ExecuteReader();
             DropDownList1.DataValueField = "Fence_Name";
              DropDownList1.DataTextField = "Fence_Name";
            DropDownList1.DataBind();
             con.Close();
         }
    }
