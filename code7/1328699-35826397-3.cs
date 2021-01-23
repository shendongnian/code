    [HttpPost]
    public JsonResult Calculate(double initVlaue, double regValue)
    {
        var result = CommonComputation.CalcuEnga(initVlaue, regValue);
        return Json(result.ToString("#.#"));
    }
