    protected bool UpdateIfChanged(Product entity, ProductModel item)
    {
        var areEqual = CompareProductAndProductModel(entity, item);
        
        if(!areEqual)
            UpdateProduct(MapProductModelToProduct(item));
    
        return !areEqual;
    }
    
    internal bool CompareProductAndProductModel(Product product, ProductModel productModel)
    {
        return product.Title == productModel.Title && product.ServerId == productModel.Id; //could be abstracted to an equality comparer if you were inclined
    }
