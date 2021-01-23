        if (Session["IsLog"] == null)
        {
            Response.Redirect("Error.aspx");
        }
        if (Session["IsLog"].ToString() != "true")
        {
            Response.Redirect("Error.aspx");
        }
 
