    public int? tempResult
    {
         get { return Convert.ToInt32(Session["tempResult"]); }
         set { Session["tempResult"] = value; }
    }
