    public override PageLoad()
    {
        if (Session["user"] != null)
        {
            string loginMsg = Session["user"] as string;
            sessionUser.InnerHtml = "Hello, " + loginMsg;
        }
    }
