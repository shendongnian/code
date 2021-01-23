     protected void Page_Load(object sender, EventArgs e)
            {
                if (Header.Controls[1].GetType() != typeof(System.Web.UI.HtmlControls.HtmlMeta))
                {
                    System.Web.UI.HtmlControls.HtmlMeta meta = new System.Web.UI.HtmlControls.HtmlMeta();
                    meta.HttpEquiv = "X-UA-Compatible";
                    meta.Content = "IE=edge";
                    this.Header.Controls.AddAt(1, meta);
                }
