    ProductViewModel model = new ProductViewModel();
    
    model.AvailableQuantities.AddRange(model.Quantities.Select(item => new SelectListItem
    {
        Text = item.ToString(),
        Value = item.ToString()
    });
