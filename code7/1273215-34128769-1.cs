      if (!ModelState.IsValid)
                {
                    bool confirmation;
                    if (bool.TryParse(Request["Confirmation"], out confirmation))
                        return View(request);
                    return RedirectToAction("Http404", "Errors"); //This not just redirects 404, it has also tracking/blocking ip algorithm.
                }
               
