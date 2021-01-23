    public IActionResult Index([FromServices] IConfiguration config) 
    {
    BillModel model= config.GetSection("Yst.Requisites").Get<BillModel>();
    return View(model);
    }`
