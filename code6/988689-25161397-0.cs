    [HttpPost]
    public ActionResult Edit([Bind(Exclude = "AmountBox")] SomeClass model)
    {
        //
    }
