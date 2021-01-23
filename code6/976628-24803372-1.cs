    [Route("{id:int:min(1)}/addDesign")]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> AddDesign(Design model)
    {
        List<FeaturedProductTypes> productCollection = model.FeaturedProductTypes.ToList();
        productCollection.Add(model.AddedItem);
        model.FeaturedProductTypes = productCollection.ToArray();
        //do something more
    }
