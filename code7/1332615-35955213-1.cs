    protected void lbtnRegister_Click(object sender, EventArgs e)
        {
            HtmlGenericControl myObject = this.FindControl("ContentPlaceHolder1").FindControl("divShow") as HtmlGenericControl;
            myObject.Style.Add("display", "none");
        }
