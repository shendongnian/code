    [HttpPost]
    public virtual ActionResult ActionName([Bind(Prefix = "actionMode")]bool isYesActionMode, MyViewModel)
    // Bind attribute used to get value from old parameter name
    {
        if (isYesActionMode)
            return RedirectToAction("actionName1");
        
        return RedirectToAction("actionName2", new { data = MyViewModel.data });
    }
