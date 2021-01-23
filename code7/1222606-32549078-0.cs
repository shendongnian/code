    protected override DriverResult Editor(
        ProductPart part,
        IUpdateModel updater,
        dynamic shapeHelper)
    {
        var model = new EditLeavesViewModel<ProductLeafEntry>();
        if (updater.TryUpdateModel(model, Prefix, null, null))
        {
            // set the property manually here
            part.ProductsContent = model.ProductsContent;
            if (part.ContentItem.Id != 0)
            {
                _productService.UpdateLeavesForContentItem(
                    part.ContentItem, model.Leaves);
            }
        }
        return Editor(part, shapeHelper);
    }
