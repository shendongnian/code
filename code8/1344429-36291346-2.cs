    [ValidateAssembly]
    public JsonResult DatatableRequest(string className)
    {
        Type.GetType(className);
        //more stuff + response
    }
