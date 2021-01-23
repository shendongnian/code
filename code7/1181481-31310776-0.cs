    [HttpGet]
    [ODataRoute("Books({key})/Press/{pName:dynamicproperty}")]
    public IHttpActionResult XxxxDynamicPropertyXxxx([FromODataUri] string key, [FromODataUri] string pName)
    {
    ...
    }
