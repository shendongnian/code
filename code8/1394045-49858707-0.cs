    public ViewResult IndexWithServiceLocatorPattern([FromServices]ProductTotalizer totalizer)
    {
        var repository = (IRepository)HttpContext.RequestServices.GetService(typeof(IRepository));
        ViewBag.HomeController = repository.ToString();
        ViewBag.Totalizer = totalizer.repository.ToString();
        return View("Index", repository.Products);
    }
