    [HttpGet]
    public async Task<IActionResult> GetProduct([FromRoute] int id)
    {
        return Ok(await _context.Products
            .Include(p => p.Markets)
            .SingleAsync(m => m.ProductID == id));
    }
