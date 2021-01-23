    [HttpGet]
    public PartialViewResult FilterProducts(FilterDto filters)
    {
        FilterModel filterModel = Mapper.Map<FilterModel>(filters);
        List<Product> products = productsService.FilterBy(filterModel);
        return PartialView("_LoadProducts", products);
    }
