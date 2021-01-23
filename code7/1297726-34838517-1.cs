    protected void Page_Load(object sender, EventArgs e){
        if (!IsPostBack){
            BindDDL();
            BindGrid(ddlClassDate.SelectedValue);
        }
    }
    protected void BindDDL(){
        //Bind Your dropdownlist here
    }
    protected void BindGrid(string ddate){
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["gescdb"].ConnectionString);
        SqlCommand comm = new SqlCommand("select * from gescdb where ClassDate = @date", conn);
        comm.Parameters.Add("@date", SqlDbType.VarChar).Value = ddate;
        try
        {
            conn.Open();
            SqlDataAdapter sda = new SqlDataAdapter(comm);
            DataSet ds = new DataSet();
            sda.Fill(ds);                
            GridRegistrants.DataSource = ds;
            GridRegistrants.DataBind();
        }
        catch
        {
            //...
        }
        finally
        {              
            conn.Close();
        }
    }
    protected void ddlClassDate_SelectedIndexChanged(object sender, EventArgs e){
        BindGrid(ddlClassDate.SelectedValue);
    }
