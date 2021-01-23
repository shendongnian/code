    protected void btnAdd_Click(object sender, EventArgs e)
        {
            PanelPurchase.Visible = true;
            Response.Write("server working");
            Page.ClientScript.RegisterStartupScript(this.GetType(),"CallMyFunction","MyFunction()",true);
        }
