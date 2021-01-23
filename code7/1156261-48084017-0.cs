    public string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            try
            {
                Session["UserID"] = "100";
                //int ID = 102;
                int ID = Convert.ToInt32(Request.QueryString["ID"].ToString());
                Session["Product_ID"] = ID;
                if (Session["UserID"] == null || Session["UserID"].ToString() == string.Empty)
                {
                    Response.Redirect("Login.aspx", false);
                }
                else
                {
                    if (ID != null)
                    {
                        
                        DataTable dt = Load_Items_ID(Convert.ToInt32(Session["UserID"].ToString()), ID);
                        lbl_Name.Text = dt.Rows[0]["Name"].ToString();
                        lbl_Price.Text = dt.Rows[0]["Price"].ToString();
                        lbl_Details.Text = dt.Rows[0]["Details"].ToString();
                        img_Product.ImageUrl = dt.Rows[0]["image"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('An Error has been occured ');" + ex.ToString(), true);
            }
        }
    }
    public DataTable Load_Items_ID(int UserID, int ID)
    {
        DataTable Returned_Value = new DataTable();
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM  Products  where  UserID= " + UserID + " and  Status='False'  and  ID =" + ID))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(Returned_Value);
                    }
                }
            }
        }
        return Returned_Value;
    }
}
