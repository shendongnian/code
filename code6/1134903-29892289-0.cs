    [HttpPost]
    public virtual ActionResult ActionName(string actionMode, MyViewModel)
    {
        if (actionMode == "yes")
            return RedirectToAction("actionName1");
        return RedirectToAction("actionName2", new { data = MyViewModel.data });
    }
