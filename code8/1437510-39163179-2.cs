    [Route("~/shop/[action]")]
    public IActionResult Update([FromBody] Shop shop)
    {
        var shopData = _context.Shops.Single(s => s.Id == shop.ShopId);
    
        // Copying properties to existing object
        mapper.Map<Shop, Shop>(shop, shopData);
        _context.SaveChanges();
        return new JsonResult(new { result = true });
    }
