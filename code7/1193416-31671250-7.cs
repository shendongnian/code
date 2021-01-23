     public partial class header_cy_GB : System.Web.UI.UserControl
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                string currentPage = Request.Url.AbsoluteUri.ToString();
    
                NameValueCollection qsexisting = HttpUtility.ParseQueryString(Request.QueryString.ToString());
                //find anyting called lang in the array and remove
                qsexisting.Remove("lang");
    
                var qs = Request.QueryString;
    
                //The culture is welsh, set stuff to English
                if (Thread.CurrentThread.CurrentCulture.ToString() == "cy-GB")
                {
                    Uri uri = new Uri(currentPage);
                    languagelink.HRef = String.Format(uri.GetLeftPart(UriPartial.Path) + "?lang=en-GB" + (qsexisting.ToString() == "" ? "" : "&" + qsexisting.ToString()));
                }
            }
    
            protected void LoginStatus1_LoggedOut(object sender, EventArgs e)
            {
                Response.Redirect("~/LogIn.aspx");
            }
        }
