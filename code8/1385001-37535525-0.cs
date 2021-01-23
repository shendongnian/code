    public ActionResult CreateChild(int parentId)
    {
        ...
        // convert parentId into Base64
        ViewBag.ParentID = Convert.ToBase64String(parentId);
        return View(ViewBag); // model binding
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult CreateChild([Bind(Include = "Id,Name,Unit,UnitPrice,MaterialPaymentRequestId,Quantity,ParentID")] MaterialPaymentRequestSubItem materialpaymentrequestsubitem)
    {
         ...
         // get Parent ID
         int parentId = (int)Convert.FromBase64String(ParentID);
    
         // write your own algorithm to validate hidden field's value
         ...
         if (ModelState.IsValid) 
         {
              // redirect to create child elements
              return RedirectToAction("CreateChild", "Controller", new { @id = parentId });
         }
    }
