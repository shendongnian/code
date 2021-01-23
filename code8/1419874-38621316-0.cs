    [HttpPost]
    public ActionResult Sum(CalculatorModel model)
    {
        ModelState.Clear();
        model.Result = model.FirstOperand + model.SecondOperand;         
        return View(model);
    }
