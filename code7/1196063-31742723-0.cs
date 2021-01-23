    public ActionResult CarList()
    {
        using(var carStore = new Factory.CreateCarStore())
        {
             var result = carStore.GetActiveCars();
             return View(result);
        }
    }
