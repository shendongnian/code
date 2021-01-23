        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id">The id.</param>
        /// <param name="form">The form.</param>
        /// <returns></returns>
        [HttpPost, ValidateInput(false)]
        public virtual async Task<ActionResult> Edit(string Id, FormCollection form)
		{
			var model = (await _domainService.Get(x=>x.Id == Id)).FirstOrDefault();
			if (TryUpdateModel(model))
			{
                await _domainService.Save(model);
				return RedirectToAction("Details", new { id = Id, ....});
			}
			return View(model);
		}
