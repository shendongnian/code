    public IHttpActionResult ApiMethod()
    {
      ...
      return Content(HttpStatusCode.OK, Model, Configuration.Formatters.XmlFormatter);
    }
