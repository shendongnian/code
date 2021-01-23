    public void ShowBanner()
    {
     HttpCookie BannerCookie = Request.Cookies["ShowBanner"];
     if (BannerCookie != null)
     {
     Panel1.Visible = false;
     }
    else{
    Panel1.Visible = true;
    }
    }
