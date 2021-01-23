    [HttpPost]
    public async Task<ActionResult> Index(MyViewModel model)
        {
            //...
            if (model.SearchString != null)
            {
                //...
                var a = model.FirstInt;
                var b = model.SecondInt;
            }
            //...
            return View(model);
        }
