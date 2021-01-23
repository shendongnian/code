     protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "ViewPDF")
            {
                Response.Redirect("~/MyPDFFiles/" + (string)e.CommandArgument);
            }
        }
