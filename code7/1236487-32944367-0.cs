    context.Response.Redirect("~/Main.aspx?userid=1234&pagestate=5");
    Page_Load(object sender, EventArgs e)
    {
         int userid = Request.QueryString["userid"];
         int pagestate = Request.QueryString["pagestate"];
         if(user != 0 && pagestate == 5)
         {
             //configure page for the reloaded state ie. once you reload it with this variable, how is it different to without this variable.
         }
    }
