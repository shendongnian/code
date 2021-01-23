    protected void repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "addtoCartName")
        {
            TextBox txtName = (TextBox)e.Item.FindControl("txtQuantity")
            if (txtName!= null)
            {
                strText = strText + ", " + txtName.Text;
                Response.Write("Text =" + strText);
            }
       }
    }
