      string url = SPContext.Current.Site.ServerRelativeUrl;
            if (!url.EndsWith("/"))
            {
                url += "/";
            }
    HtmlGenericControl styleCss = new HtmlGenericControl("link");
            styleCss.Attributes.Add("rel", "stylesheet");
            styleCss.Attributes.Add("type", "text/css");
            styleCss.Attributes.Add("href", url + "Style Library/css/style.css");
    HtmlGenericControl JsLink = new HtmlGenericControl("script");
            JsLink.Attributes.Add("src", url + "Style    Library/js/jquery.min.js");`enter code here`
    this.Controls.Add(styleCss);
    this.Controls.Add(JsLink);
    
