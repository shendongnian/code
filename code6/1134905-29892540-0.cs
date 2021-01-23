    [HttpPost]
    public virtual ActionResult ActionName(string actionMode, MyViewModel)
    {
        switch (actionMode)
        {
            case "yes":
                return RedirectToAction("actionName1");
            default:
                return RedirectToAction("actionName2", new { data = MyViewModel.data });
        }
    }
