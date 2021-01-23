     if (!string.IsNullOrEmpty(Request.QueryString["Lang"]))
        {
            HttpCookie myCookie = (HttpCookie)Request.Cookies["cLang"];
            if (myCookie != null)
            {
                if (myCookie["Lang"] != Request.QueryString["Lang"].ToString())
                {
                    myCookie["Lang"] = Request.QueryString["Lang"].ToString();
                    myCookie.Expires = DateTime.Now.AddYears(1);
                    Response.Cookies.Add(myCookie);
                    System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(Request.QueryString["Lang"]);
                    System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture(Request.QueryString["Lang"]);
                    Response.Redirect(Request.Url.AbsoluteUri);
                }
            }
            else
            {
                string strLang = Request.QueryString["Lang"];
                myCookie = new HttpCookie("cLang");
                myCookie.Values.Add("Lang", strLang);
                myCookie.Expires = DateTime.Now.AddYears(1);
                Response.Cookies.Add(myCookie);
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(strLang);
                System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture(strLang);
            }
        }
