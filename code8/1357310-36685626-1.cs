    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "readmore")
            {
                Session["messageid"] = e.CommandArgument.ToString();
                Response.Redirect("popuppage.aspx?id=" + Session["messageid"].ToString() + "");
            }
        }
