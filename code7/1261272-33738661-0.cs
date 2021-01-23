    [HttpGet]
    public ActionResult Products(int? OrderBy, int page = 1, int pageSize = 2)
    {
        ViewBag.OrderBy = OrderBy;
        ...
