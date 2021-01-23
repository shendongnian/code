    public string SelectedVariation(string mealsAttribute, string portionsAttribute, string product)
    {
        Guid productId = new Guid(product);
        CatalogManager catalogManager = CatalogManager.GetManager();
        EcommerceManager ecommerceManager = EcommerceManager.GetManager();
    
        RegisterOrderAccountFormModel model = new RegisterOrderAccountFormModel();
        model.Product = catalogManager.GetProduct(productId);
        List<ProductVariation> productVariationsCollection = catalogManager.GetProductVariations(productId).ToList();
        //This is the really interesting part for the answer:
        return productVariationsCollection.Where(x => x.Variant.ToLower().Contains(mealsAttribute.ToLower()) && x.Variant.ToLower().Contains(portionsAttribute.ToLower())).FirstOrDefault().Id.ToString();
    }
