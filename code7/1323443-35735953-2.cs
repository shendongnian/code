    public static void SetCampanhaInstitucional(List<CampanhaInstitucionalModel> CampanhaInstitucional)
    {
        if (CampanhaInstitucional != null)
        {
            string campanha = JsonConvert.SerializeObject(CampanhaInstitucional);
            HttpCookie theCookie = new HttpCookie(cookienameRodape, campanha);
            theCookie.Expires.AddDays(7); //Keep the cookie alive for 7 days
            HttpContext.Response.Cookies.Add(theCookie); //add the cookie to the response
            //alternatively you could also use
            //HttpContext.Response.SetCookies(theCookie);
        }
    }
