    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            MyFunction();
    }
    protected void MyFunction()
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-CEUQVES;Initial Catalog=register;Integrated Security=True;Pooling=False");
        con.Open();
        SqlDataAdapter sda = new SqlDataAdapter("select * from Admintr where projectid=mba ", con);
        DataSet ds = new DataSet();
        sda.Fill(ds);
        if (ds.Tables[0].Rows.Count > 0)
        {
            GridView1.DataSource = ds;
            GridView1.DataBind();
            //GridView1.Columns[0].Visible = false;
        }
    }
    protected void Unnamed_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "view")
        {
            string str = e.CommandArgument.ToString();
            Response.ContentType = "image/jpg";
            Response.AddHeader("Content-Disposition", "attachment;filename=\"" + str + "\"");
            Response.TransmitFile(Server.MapPath(str));
            Response.End();
        }
    }
  
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Write("<script language='javascript'>alert('Button is working');</script>");
    }
