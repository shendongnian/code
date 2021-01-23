    [HttpPost]
    public ActionResult ProductsCheaperThan(decimal comparisonPrice)
    {
        ViewBag.FilterPrice = comparisonPrice;
        var resultSet = new ProductService().GetProductsCheaperThan(comparisonPrice);
        return View(resultSet);
    }
