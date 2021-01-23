    [HttpGet]
    [Authorize(Policy = PermissionEnum.PERSON_LIST.ToString())]
    public ActionResult Index(PersonListQuery query)
    {
        ...
    }
