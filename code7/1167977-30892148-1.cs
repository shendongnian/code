            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult YourMethod(ModelName model)
            {
              if(partialSave) // Check here whether it's a partial or full submit
              {
                ModelState.Remove("PropertyName");
                ModelState.Remove("PropertyName2");
                ModelState.Remove("PropertyName3");
              }
              if (ModelState.IsValid)
              {
              }
            }
