    Public ActionResult yourMethod()
    {
         if (ModelState.IsValid)
         {
            // Your code
         }
         else
         {                
            return View("Same View");
         }  
    }
