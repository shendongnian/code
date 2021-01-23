    builder.Register(c =>
    {
        if (HttpContext.Current == null)
        {
            throw new Exception("no httpcontext available");
        }
        ICore core = HttpContext.Current.Session["ICore"] as ICore;
        if (core == null)
        {
            core = new Core();
            HttpContext.Current.Session["ICore"] = core;
        }
        return core;
    }).As<ICore>();
