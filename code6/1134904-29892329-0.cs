    [HttpPost]
    public virtual ActionResult ActionName(string actionMode, MyViewModel)
    {
        return actionMode == "yes" ? RedirectToAction("actionName1") : RedirectToAction("actionName2", new { data = MyViewModel.data });
    }
