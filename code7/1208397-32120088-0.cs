    //if you are loading the new page
    if (!Page.IsPostBack)
    {
        if(Session["Step02AllServices"] != null)
        {
            Step02AllServices.Checked = (bool) Session["Step02AllServices"];
            //similarly assign other checkbox values as they are in session already
        }
        else
        {
            //do normal assignment
        }
    }
