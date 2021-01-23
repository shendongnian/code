    public static void callJavascriptFunction(string strScript)
        {
            
                if (HttpContext.Current == null && HttpContext.Current.Handler is Page) { return; }
    
                Page currentPage = (Page)HttpContext.Current.Handler;
                ScriptManager.RegisterStartupScript(currentPage,
                                                    currentPage.GetType(),
                                                    "Funct",
                                                    strScript,
                                                    true);
        }
