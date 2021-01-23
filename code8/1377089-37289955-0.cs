    protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["IslandGasAdminST"] != null)
            {
                if (!IsPostBack)
                {
                    Label1.Text = "- Supply & Transport Manager";
                    GetOrderList();
                }
                //else
                //{
                //    Response.Write("<script>alert('Supply & Transport Manager credentials needed'); window.location.href='LogIn.aspx';</script>");
                //}
            }
            else
            {
                Response.Write("<script>alert('Supply & Transport Manager credentials needed'); window.location.href='LogIn.aspx';</script>");
            }
        }
