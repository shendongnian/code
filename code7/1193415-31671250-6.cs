    public partial class header : System.Web.UI.UserControl
        {
            protected void Page_Load(object sender, EventArgs e)
            {
               string currentPage = Request.Url.AbsoluteUri.ToString();
    
                NameValueCollection qsexisting = HttpUtility.ParseQueryString(Request.QueryString.ToString());
    
                //find anyting called lang in the array and remove
                qsexisting.Remove("lang");
    
                //The culture is English, set stuff to Welsh
                if (Thread.CurrentThread.CurrentCulture.ToString() == "en-GB")
                {
                    Uri uri = new Uri(currentPage);
                    languagelink.HRef = String.Format(uri.GetLeftPart(UriPartial.Path) + "?lang=cy-GB" + (qsexisting.ToString() == "" ? "" : "&" + qsexisting.ToString()));                
                }
            }
    
            protected void LoginStatus1_LoggedOut(object sender, EventArgs e)
            {
                Response.Redirect("~/LogIn.aspx");
            }
        }
