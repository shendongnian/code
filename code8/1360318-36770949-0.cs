    [TestMethod]
    public void TestMethod2()
    {
      MessageController controller = new MessageController();
      ActionResult result = controller.Index(1);
      Assert.IsInstanceOfType(result, typeof(ViewResult));
      //Since view has been asserted as ViewResult
      ViewResult viewResult = result as ViewResult;  
      if(viewResult != null)
      {      
         Assert.IsInstanceOfType(viewResult.Model, typeof(YourModelType));
        //Further Asserts for your model 
      } 
    }
