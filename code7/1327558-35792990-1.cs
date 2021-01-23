    [MyAuthorize]
    public IHttpActionResult Get(int id)
    {
        try
        {
            // At this stage you know that the user is authorized to
            // access the requested resource
            var customer = customerService.GetById(id);
            return Ok(customer);
        }
        catch (BusinessLogicException e)
        {
            return CreateErrorResponse(e);
        }
    }
