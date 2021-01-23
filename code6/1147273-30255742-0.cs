    [HttpGet]
    public HttpResponseMessage getData()
    {
       var result = repository.BindDatatable();
    }
