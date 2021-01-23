    public class AppSession
    {
    public static string UserName
        {
            set
            {
                HttpContext.Current.Session["UserName"] = value;
            }
            get
            {
                if (HttpContext.Current.Session["UserName"] != null)
                {
                    return HttpContext.Current.Session["UserName"].ToString();
                }
                else
                    return null;
            }
        }
    }
