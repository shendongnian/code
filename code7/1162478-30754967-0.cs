            HttpCookie Cookie = new HttpCookie("cksunlightitmailid");
            Cookie.Value = txtSunlightitmailid.Text.Trim();
            Cookie.Expires = DateTime.MaxValue; // never expire
            HttpContext.Current.Response.Cookies.Add(Cookie);
            HttpCookie ck_d = Request.Cookies["cksunlightitmailid"];
    if (Request.Cookies["cksunlightitmailid"] != null)
            {
                lblSunlightitmailid.Text = "Ur current email id :" + Request.Cookies["cksunlightitmailid"].Value;
                //Or Write ur own code here
            }
