    public virtual ActionResult Edit(TEditDTO editedDTO)
    {
        if (!ModelState.IsValid) return View(editedDTO); 
        PropertyInfo prop = typeof(editedDTO).GetProperty("Id") ;
        Object Id = prop.GetValue(editedDTO); 
    }
