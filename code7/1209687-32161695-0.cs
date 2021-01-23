    [HttpPost]
    [ValidateAntiForgeryToken]
    public JsonResult Action(MySuperModel Model, HttpPostedFileBase file)
    {           
            // Some file validation
    
            if (ModelState.IsValid)
            {
                // Updating the database and sets Model to its new values.                    
            }
    
        return (result.ToHtmlString(), JsonRequestBehavior.AllowGet)
    }
