    public ActionResult _Add(WebApplication1.Models.Category model)
    {
        int id;
            
        if (ModelState.IsValid)
        {
            id = _documentsRepository.SetCategory(model);
        }
        else
        {
            ModelState.Clear();
            return PartialView(model);
        }
        return Content(id.ToString());
    }
