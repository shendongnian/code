    public TestController
    {
        public ActionResult TestMethod(ModelName model)
        {
            //This will be false if your ModelState validator fails.
            if(ModelState.IsValid)
            {
                ....
            }
        }
    }
