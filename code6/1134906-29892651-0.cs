    [HttpPost]
    public virtual ActionResult ActionName(string actionMode, MyViewModel)
    {
        switch (actionMode)
        {
            case "yes":
                return RedirectToAction("actionName1");
            case "no":
                return RedirectToAction("actionName2", new { data = MyViewModel.data });
            default:
                goto case "yes"; // yes behavior by default
        }
    }
