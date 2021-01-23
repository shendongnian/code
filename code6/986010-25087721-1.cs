        using System;
        using System.Collections.Generic;
        using System.Linq;
        using System.Web;
        using System.Web.Services;
        using System.Web.UI;
        using System.Web.UI.WebControls;
        
        namespace WebApplication1
        {
        public partial class WebForm1 : System.Web.UI.Page
        {
        static int x = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie hc = new HttpCookie("kk", "kk");
            hc.Expires = DateTime.Now.AddMinutes(5);
            Response.Cookies.Add(hc);
        }
        [WebMethod(EnableSession = true)]
        public static String PokePage()
        {
            HttpCookie hc = new HttpCookie("kk", "kk");
            hc.Expires = DateTime.Now.AddMinutes(-5);
            HttpContext.Current.Response.Cookies.Add(hc);
            return "http://www.google.com";
        }
        }
        }
