        protected void Application_EndRequest()
        {            
            if (Context.Response.StatusCode == 404)
            {
                Log.Debug("Application_EndRequest:" + Context.Response.StatusCode + "; Url=" + Context.Request.Url);
                Response.Clear();
                string language = LanguageUtil.Instance.MapLanguageCodeToWebsiteUrlLanguage(HttpContext.Current.Request, Thread.CurrentThread.CurrentUICulture.Name);
                var rd = new RouteData();
                //rd.DataTokens["area"] = "AreaName"; // In case controller is in another area
                rd.Values["languageCode"] = language;
                rd.Values["controller"] = "Error404";
                rd.Values["action"] = "Index";
                Response.TrySkipIisCustomErrors = true;
                IController c = new Controllers.Error404Controller();
                c.Execute(new RequestContext(new HttpContextWrapper(Context), rd));
            }
            else if (Context.Response.StatusCode == 500)   
            {
                Log.Debug("Application_EndRequest:" + Context.Response.StatusCode + "; Url=" + Context.Request.Url);
                Response.Clear();
                string language = LanguageUtil.Instance.MapLanguageCodeToWebsiteUrlLanguage(HttpContext.Current.Request, Thread.CurrentThread.CurrentUICulture.Name);
                Response.Redirect("~/" + language + "/error");
            }
        }
