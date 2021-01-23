    public ActionResult ToggleProductPromoCodeIsActive(string promoCode, string productID, string countryCode)
    {
        var isActive = _productPromoCodeRepository.ToogleActive(promoCode, productID, countryCode);// This encapsulates the three lines of code from above...
        return Json(new { isActive = isActive }, JsonRequestBehavior.AllowGet);
    }
    
    public ActionResult AddPromoCodeProperties(string promoCode, DateTime beginningDateTime, DateTime endDateTime, bool isActive, int? length, string countryCode, short? maximumRenewals)
    {
        var productPromoCode = _productPromoCodeRepository.Get(promoCode, productID/*I don't know where do you get this value*/, countryCode);
        if(productPromoCode != null)
            return Json(new { message = "Failed: The same promo code with the same country code has existed", promoCode = promoCode }, JsonRequestBehavior.AllowGet);
        
        productPromoCode = new ProductPromoCode();
        productPromoCode.code = promoCode;
        productPromoCode.discountPercentage = discountPercentage;
        productPromoCode.productID = productID;
        productPromoCode.isActive = isActive;
        productPromoCode.countryCode = countryCode;
        productPromoCode.paymentPageText = paymentPageText;
        productPromoCode.finalProductID = finalProductID;
        _productPromoCodeRepository.Create(productPromoCode);
        // you can actually move all these lines above to the repo with another overload for the Create method that takes all the parameters.
        
        // Here you can be sure the item didn't exist before in the database, but you would have to deal with errors in the creation and return the proper error message.
        return Json(new { message = "Promo code properties have been succesfully added", id = productPromoCode.id, promoCode = productPromoCode.code }, JsonRequestBehavior.AllowGet);
        
    }
