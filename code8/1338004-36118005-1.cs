    public async Task <ActionResult > AddComent(IEnumarable<ReviewViewModel> reviews)
    {
        if (ModelState.IsValid)
        {
            //Mapping ViewModel to DomainModel (Review > ReviewViewModel)
            var viewModel = new ReviewViewModel();
            AutoMapper.Mapper.CreateMap<Review , ReviewViewModel>();
            AutoMapper.Mapper.Map(model, viewModel);
            //
            db.Comments.Add(model);
            await db.SaveChangesAsync();
            return RedirectToAction("index");
        }
        return View(model);
    }
