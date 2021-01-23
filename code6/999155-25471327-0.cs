    [HttpPost]
    public ActionResult DeleteItem(Guid id)
    {
        ItemService.Delete(id);
    
        return RedirectToAction("Index");
    }
