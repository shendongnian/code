    protected override void InitializeCulture()
        {
            string language = "en-GB";
            //Detect User's Language.
           // if (Request.UserLanguages != null)
           // {
                //Set the Language.
          //      language = Request.UserLanguages[0];
          //  }
            //Check if PostBack is caused by Language DropDownList.
            if (Request.Form["__EVENTTARGET"] != null && Request.Form["__EVENTTARGET"].Contains("ddlLanguages"))
            {
                //Set the Language.
                language = Request.Form[Request.Form["__EVENTTARGET"]];
                Session["language"]=language.ToString();
            }
          else
           {
                if(Session["language"] !=null){
                language=Session["language"].ToString();
                 }
           }
            //Set the Culture.
            Thread.CurrentThread.CurrentCulture = new CultureInfo(language);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);
        }
