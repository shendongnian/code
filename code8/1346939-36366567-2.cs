    protected override void Initialize(System.Web.Routing.RequestContext requestContext)
    {
       base.Initialize(requestContext);
       //// access session here
       requestContext.HttpContext.Session["company-cellphone"]=mng.GetContacts().CompanyCellphone;
    }
