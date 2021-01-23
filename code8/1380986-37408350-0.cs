    foreach (Control c in this.Controls.OfType<System.Web.UI.WebControls.PlaceHolder>().ToList())
    {
        foreach (Control cc in c.Controls.OfType<System.Web.UI.HtmlControls.HtmlGenericControl>().ToList())
        {
            if (cc is System.Web.UI.HtmlControls.HtmlGenericControl)
            {
                System.Web.UI.HtmlControls.HtmlGenericControl iframe = cc as System.Web.UI.HtmlControls.HtmlGenericControl;
                if (iframe.Attributes["src"].Contains("slideshare"))
                {
                    Response.Write("INDEX:"+c.Controls.IndexOf(cc)); // returns -1 
                    iframe.Attributes["src"] = "/img/content/cookielaw_slideshare.jpg";
                    Literal lit=new Literal();
                    lit.Text = @"<div class='cookieLaw_slideshare'><a id='cookieLaw_slideshare' href='#'><img src='/img/content/cookielaw_slideshare.jpg'/></a></div>";
                    break;
                }
            }
        }
        Page.Controls.AddAt(c.Controls.IndexOf(cc),lit);
    }
