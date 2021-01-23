    [HttpPost]
    public ActionResult Register(Models.Parent register)
    {
        return Content(register.ReceivesNewsLetter.ToString());
    }
