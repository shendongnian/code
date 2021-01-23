    protected void UpdatePanel1_Load(object sender, EventArgs e)
    {
        if (Session["percent"] != null)
        {
            Label_For_Server_Time.InnerText = Session["percent"].ToString();
        }
    }
