    protected void Page_Load(object sender, EventArgs e)
        {       
            ContentPlaceHolder mainContent = (ContentPlaceHolder)this.Master.FindControl("body");
            HtmlGenericControl footer = (HtmlGenericControl)mainContent.FindControl("editor");
            String cmd = footer.InnerHtml.ToString();
            TextBox1.Text = cmd;
        }
