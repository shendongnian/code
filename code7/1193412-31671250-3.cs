    public partial class BasePage : System.Web.UI.Page
        {
            protected override void InitializeCulture()
            {
                if (Session["language"] == null)
                {
                    Session["language"] = "en-GB";
                }
    
                else
                {
                    if (Request.QueryString["lang"] == null)
                    {
                        SetSessionCulture();
                    }
    
                    if (Request.QueryString["lang"] != null)
                    {
                        string qs = Request.QueryString["lang"];
                        Session["language"] = qs;
                    }
    
                    SetSessionCulture();
                }
    
                SetSessionCulture();           
            }
    
            private void SetSessionCulture()
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(Session["language"].ToString());
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(Session["language"].ToString());
                base.InitializeCulture();
            }
        }
