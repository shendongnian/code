    protected void Page_Load(object sender, EventArgs e)
    {
    if (!IsPostBack)
    {
    BindGridview();
    }
    }
    protected void BindGridview()
    {
    DataSet ds = new DataSet();
    using (SqlConnection con = new SqlConnection("Data Source=Suresh;Integrated Security=true;Initial Catalog=MySampleDB"))
    {
    con.Open();
    SqlCommand cmd = new SqlCommand("crudoperations", con);
    cmd.CommandType= CommandType.StoredProcedure;
    cmd.Parameters.AddWithValue("@status","SELECT");
    SqlDataAdapter da = new SqlDataAdapter(cmd);
    da.Fill(ds);
    con.Close();
    if (ds.Tables[0].Rows.Count > 0)
    {
    gvDetails.DataSource = ds;
    gvDetails.DataBind();
    }
    else {
    ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
    gvDetails.DataSource = ds;
    gvDetails.DataBind();
    int columncount = gvDetails.Rows[0].Cells.Count;
    gvDetails.Rows[0].Cells.Clear();
    gvDetails.Rows[0].Cells.Add(new TableCell());
    gvDetails.Rows[0].Cells[0].ColumnSpan = columncount;
    gvDetails.Rows[0].Cells[0].Text = "No Records Found";
    }
    }
    }
    protected void gvDetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {
    if (e.CommandName.Equals("AddNew"))
    {
    TextBox txtname = (TextBox)gvDetails.FooterRow.FindControl("txtpname");
    TextBox txtprice = (TextBox)gvDetails.FooterRow.FindControl("txtprice");
    crudoperations("INSERT", txtname.Text, txtprice.Text, 0);
    }
    }
    protected void gvDetails_RowEditing(object sender, GridViewEditEventArgs e)
    {
    gvDetails.EditIndex = e.NewEditIndex;
    BindGridview();
    }
    protected void gvDetails_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
    gvDetails.EditIndex = -1;
    BindGridview();
    }
    protected void gvDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
    gvDetails.PageIndex = e.NewPageIndex;
    BindGridview();
    }
    protected void gvDetails_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
    int productid = Convert.ToInt32(gvDetails.DataKeys[e.RowIndex].Values["productid"].ToString());
    TextBox txtname = (TextBox)gvDetails.Rows[e.RowIndex].FindControl("txtProductname");
    TextBox txtprice = (TextBox)gvDetails.Rows[e.RowIndex].FindControl("txtProductprice");
    crudoperations("UPDATE",txtname.Text,txtprice.Text,productid);
    }
    protected void gvDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
    int productid = Convert.ToInt32(gvDetails.DataKeys[e.RowIndex].Values["productid"].ToString());
    string productname = gvDetails.DataKeys[e.RowIndex].Values["productname"].ToString();
    crudoperations("DELETE",productname,"",productid);
    }
    protected void crudoperations(string status, string productname, string price, int productid)
    {
    using (SqlConnection con = new SqlConnection("Data Source=Suresh;Integrated Security=true;Initial Catalog=MySampleDB"))
    {
    con.Open();
    SqlCommand cmd = new SqlCommand("crudoperations", con);
    cmd.CommandType= CommandType.StoredProcedure;
    if(status=="INSERT")
    {
    cmd.Parameters.AddWithValue("@status",status);
    cmd.Parameters.AddWithValue("@productname",productname);
    cmd.Parameters.AddWithValue("@price",price);
    }
    else if(status=="UPDATE")
    {
    cmd.Parameters.AddWithValue("@status",status);
    cmd.Parameters.AddWithValue("@productname",productname);
    cmd.Parameters.AddWithValue("@price",price);
    cmd.Parameters.AddWithValue("@productid",productid);
    }
    else if(status=="DELETE")
    {
    cmd.Parameters.AddWithValue("@status",status);
    cmd.Parameters.AddWithValue("@productid",productid);
    }
    cmd.ExecuteNonQuery();
    lblresult.ForeColor = Color.Green;
    lblresult.Text = productname+" details "+status.ToLower()+"d successfully";
    gvDetails.EditIndex = -1;
    BindGridview();
    }
    }
