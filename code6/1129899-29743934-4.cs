        public async Task<ActionResult> Index(NikolsModel model)
        {
            if (ModelState.IsValid)
            {
                //
                // Create a new instance of your entity 
                //
                var record = new NikolsEntity
                {
                    IsValid = model.IsActive ? 1 : 0,
                    //Other properties from model
                };
                DbContext.NikolsEntity.add(record);
                await DbContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            //Something went wrong, return the view with model errors
            return View(model);
            
        }
