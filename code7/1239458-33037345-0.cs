     [AllowAnonymous]
     public async Task<JsonResult> doesProductExist(string Product)
     {
        var result = 
        await userManager.FindByNameAsync(Product) ?? 
        await userManager.FindByEmailAsync(Product);
        return Json(result == null, JsonRequestBehavior.AllowGet);
     }
