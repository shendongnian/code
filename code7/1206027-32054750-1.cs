    string myScript = string.Empty;
    if (mod != 1)
    {
        myScript += "Funcm();";
    }
    
    if (ven != 1)
    {
        myScript += "Funcv();";
    }
    if (loc != 1)
    {
        myScript += "Funcl();";
    }
    if (st != 1)
    {
        myScript += "Funcst();";
    }
    if (!string.IsNullOrEmpty(myScript))
    {
        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "myScript", myScript, true);
    }
