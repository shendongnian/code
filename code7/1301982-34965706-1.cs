    Website2.aspx
    if (Request.QueryString["parm1"] != null)
    {
        boxreg.Checked = Convert.ToBoolean(Request.QueryString["parm1"]);
    }
    if (Request.QueryString["parm2"] != null)
    {
        boxhand.Checked = Convert.ToBoolean(Request.QueryString["parm2"]);
    }
        
    if (Request.QueryString["parm3"] != null)
    {
        boxbeslut.Checked = Convert.ToBoolean(Request.QueryString["parm3"]);
    }
