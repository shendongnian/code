    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["IslandGasAdminPM"] != null)
        {
            Label1.Text = "- Purchasing Manager";
        }
        else
        {
            Response.Write("<script>alert('Purchasing Manager credentials needed'); window.location.href='/LogIn.aspx';</script>");
        }
    }
