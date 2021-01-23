        /// <summary>
        /// Edits this instance.
        /// </summary>
        /// <returns></returns>
        [ValidateInput(false)]
        public virtual async Task<ActionResult> Edit(string id)
        {
			var item = (await _domainService.Get(x => x.Id == id)).FirstOrDefault();
            if (item.IsNotNull())
                return View(item);
            throw new CodedException("E.102.3");
        }
