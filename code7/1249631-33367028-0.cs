    public async Task<ActionResult> Index()
    {
      context con = new context();       
      var list = await con.dep.ToListAsync();
      IEnumerable<test> get = getL(list);
      return View(get);
    }
