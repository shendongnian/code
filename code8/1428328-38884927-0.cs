    [HttpPost]
    public ActionResult runTest(StandardTest myTest)
    {
        myTest.lastResult = MyEnum.Pass;
        log.Info(myTest.name + " " + myTest.lastResult + " " + myTest.id);
      
      if (!testPassed){        
           //test did not pass
       return Json(new {success = false,
                        responseText = "Test did not pass",JsonRequestBehavior.AllowGet);
       }
       else
       {
         //Test Passed
         return Json(new {success = true, 
                          responseText= "Test Passed"},JsonRequestBehavior.AllowGet);
         }   
    }
