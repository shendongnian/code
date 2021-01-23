    [HttpPost]
    public async Task<IActionResult> Create([Bind("X,Y,Z")] PointViewModel info)
    {
         if (ModelState.IsValid)
         {
             var point = new Point(info.X, info.Y, info.Z);
             _context.Add(point);
             await _context.SaveChangesAsync();
             return RedirectToAction(nameof(Index));
          }
          return View(info);
    }
