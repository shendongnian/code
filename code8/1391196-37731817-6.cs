    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CarModel model)
    {
        if (ModelState.IsValid)
        {
            var color = await _context.Colors.FirstAsync(c => c.CarColorId == model.ColorId, this.HttpContext.RequestAborted);
            var car = new Car();
            car.Name = model.Name;
            car.YearOfConstruction = model.YearOfConstruction;
            car.Color = color;
            
            _context.Cars.Add(car);
            await _context.SaveChangesAsync(this.HttpContext.RequestAborted);
            return RedirectToAction("Index");
        }
        return View(car);
    }
