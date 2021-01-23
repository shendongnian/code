    [Route("~/shop/[action]")]
    public IActionResult Update([FromBody] Shop shop)
    {
        var shopData = _context.Shops.Single(s => s.Id == shop.ShopId);
    
        if (shop.Name != null)
            shopData.Name = shop.Name;
        if (shop.Address != null)
            shopData.Address = shop.Address;
        _context.SaveChanges();
        return new JsonResult(new { result = true });
    }
