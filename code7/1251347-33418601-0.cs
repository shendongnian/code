    [HttpPost]
    public ActionResult Product(ProductViewModel model)
    {
    PreOrderProductCommand command = new PreOrderProductCommand();
    command.Id = model.id;    
    command.Email = model.email;
    if (ModelState.IsValid)
    {
        command.Process();
        return View("ThankYou");
    }
    else
        return Product(command.Id);
    }
