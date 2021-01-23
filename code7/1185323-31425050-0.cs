    pubilc ActionResult YourAction()
    {
       if (null == YourModel)
       {
          return View(SomeEmptyView); // or return null
       }
       return View(Some legitimate view);
    }
