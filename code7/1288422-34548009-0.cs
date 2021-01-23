        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(LetsViewModel model, IFormFile LetsImages)
        {
            LetsViewModel viewModel = null;
            try
            {
                if(!ModelState.IsValid)
                    throw new Exception("The Lets model is not valid!");
                    
                    if(LetsImages != null)
                    {
                            var targetDirectory = Path.Combine(_environment.WebRootPath, string.Format("images/uploads"));
                            var fileName = ContentDispositionHeaderValue
                            .Parse(LetsImages.ContentDisposition)
                            .FileName
                            .Trim('"');
                            var savePath = Path.Combine(targetDirectory, fileName);
                            var relPath = "/images/uploads/" + fileName;
                            try
                            {
                                LetsImages.SaveAs(savePath);
                                model.Lets.Images = relPath;
                            }
                            catch
                            {
                                throw new Exception("There was a problem with saving the file!");
                            }
                    }
                    else
                    {
                        model.Lets.Images = null;
                    }
                    model.Lets.UserId = User.GetUserId();
                    model.Lets.StatusId = 1;
        
                                              
                _kletsContext.Lets.Add(model.Lets);
                if (_kletsContext.SaveChanges() == 0)
                {
                   throw new Exception("The Lets model could not be saved!");
                }   
                
                //Success(CreateMessage(ControllerActionType.Create, "klets", model.Name), true);
                
            return RedirectToAction("Index", "Home");
            
            }
            catch(Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Unable to save changes.");
                
                viewModel = new LetsViewModel
                {
                    Lets = model.Lets,
                    Groups = _kletsContext.Groups.AsEnumerable(),
                    Letses = _kletsContext.Lets.AsEnumerable().OrderBy(m => m.Name)
                };
            }
            return View(viewModel);
        }
