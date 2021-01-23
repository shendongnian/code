    public ActionResult _Add(Models.Documents.Advisory model)
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
