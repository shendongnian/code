    private ITransform GetTransform()
    {
        var session = System.Web.HttpContext.Current.Session;
        if (session["Transform"] == null)
            session["Transform"] = new Transform();
        return (ITransform)session["Transform"];
    }
