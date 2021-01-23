    protected void Page_Load(object sender, EventArgs e)
    {
       if(!Request.IsAuthenticate)
       {
           NavPanel.Visible=false;
       }
    }
