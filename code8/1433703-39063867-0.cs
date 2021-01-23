    [HttpGet]
    public ActionResult OrderByName()
    {
         OrderList();
         ViewData["pessoas"] = listPessoas;
         return View("OrderByName");
    }
