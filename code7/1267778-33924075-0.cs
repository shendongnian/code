    public ActionResult Edit(int? id)
    {
        //don't validate this field
        ModelState.Remove("yourObject");
        if (ModelState.IsValid)
        {
            ...
        }
    }
