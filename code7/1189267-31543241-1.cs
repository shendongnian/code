    public static class DivExtensions
    {
        public static string InterstitialAd(this HtmlHelper helper)
        {
            var html = string.Empty;
            if (HttpContext.Current.Request.Cookies["Interstitial"] == null)
            {
                html = "<div class='hidden-md hidden-lg'><div class='adnl_zone id_4034'></div></div>'";
                //Create a cookie to prevent interstitial spam.
                HttpCookie Cookie = new HttpCookie("Interstitial");
                Cookie.Value = "true";
                Cookie.Expires = DateTime.Now.AddHours(1);
                HttpContext.Current.Response.Cookies.Add(Cookie);
            }
            return html;
    
        }
    }
