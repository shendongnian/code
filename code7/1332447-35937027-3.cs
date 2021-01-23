     public ActionResult YourControllerName(YourModel pageData)
      {
        return PartialView(pageData); //this requires your view to use model of type YourModel
       // OR
       // ViewBag.PageData = pageData;
       // return PartialView();
      }
